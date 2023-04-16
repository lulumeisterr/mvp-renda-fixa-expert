import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
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

  calcularAcumuloInvestimento() {
    this.calculoService.getAcumuloInvestimento({listValorAportados : this.criarObjetoParaRequisicao()}).subscribe(data => {
      if(data) {
        this.response = data;
        this.mostrarResposta = true;
      }
    });
  }

  duplicarCampo(){
    const controls = this.formulario.controls;
    for (const controlName in controls) {
      if (controlName.startsWith('campo')) {
        const novoCampo = new FormControl();
        this.formulario.addControl('campo' + (Object.keys(this.formulario.controls).length + 1), novoCampo);
        break;
      }
    }
  }

  removerCampoDuplicado(key: string) {
    if (Object.keys(this.formulario.controls).length > 1) {
      this.formulario.removeControl(key);
    }
  }
  
  limparDados() {
    this.mostrarResposta = false;
    Object.keys(this.formulario.controls).forEach(key => {
      this.formulario.get(key)?.setValue('');
    });
  }


  //#region objetos de requests
  criarObjetoParaRequisicao() : [] {
    let valores : any = [];
    const controls = this.formulario.controls;
    for (const controlName in controls) {
      if (controlName.startsWith('campo')) {
        const control = controls[controlName];
        valores.push(parseFloat(control.value));
      }
    }
    return valores;
  }
  //#endregion

}
