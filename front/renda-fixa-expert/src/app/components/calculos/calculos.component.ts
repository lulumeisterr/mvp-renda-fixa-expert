import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { tap } from 'rxjs';
import { CalculoService } from './service-calculos';

@Component({
  selector: 'app-calculos',
  templateUrl: './calculos.component.html',
  styleUrls: ['./calculos.component.scss']
})
export class CalculosComponent {

  formulario: FormGroup;
  mostrarResposta : boolean = false;
  response : any[] = [];

  constructor(private calculoService: CalculoService) {
    this.formulario = new FormGroup({
      campo: new FormControl()
    });
  }

  /**
   * Metodo responsavel por duplicar o campo
   * apos clicar no botao de adicionar.
   */
  duplicarCampo(){
    const controls = this.formulario.controls;
    for (const controlName in controls) {
        if (controlName.startsWith('campo')) {
          const control = controls[controlName];
          const novoCampo = new FormControl(control.value);
          this.formulario.addControl('campo' + (Object.keys(this.formulario.controls).length + 1), novoCampo);
          break;
        }
      }
    }

    /**
   * Metodo responsavel por remover o campo
   * apos clicar no botao de remover.
   */
  removerCampoDuplicado(key: string) {
    if (Object.keys(this.formulario.controls).length > 1) {
      this.formulario.removeControl(key);
    }
  }

  /**
   * Evento para chamar a api
   */
  calcularAcumuloInvestimento(){
    let valores : any = []
    const controls = this.formulario.controls;
    for (const controlName in controls) {
      if (controlName.startsWith('campo')) {
        const control = controls[controlName];
        valores.push(parseFloat(control.value));
      }
    }
    const body = {listValorAportados : valores}
    this.calculoService.getAcumuloInvestimento(body).subscribe(data => {
      if(data) {
        this.response = data;
        this.mostrarResposta = true;
      }
    });
  }

  limparDados() {
    this.mostrarResposta = false;
    Object.keys(this.formulario.controls).forEach(key => {
      this.formulario.get(key)?.setValue('');
    });
  }

}
