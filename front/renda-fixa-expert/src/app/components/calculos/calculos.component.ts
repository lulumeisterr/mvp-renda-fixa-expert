import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
  campos: string[] = ['campo-1'];
  campoInvalido = false;

  constructor(private calculoService: CalculoService) {
    this.formulario = new FormGroup({
      campo1: new FormControl('',Validators.required)
    });
  }

  calcularAcumuloInvestimento() {
    if (this.formulario.valid) {
      this.calculoService.getAcumuloInvestimento({listValorAportados : this.criarObjetoParaRequisicao()}).subscribe(data => {
        if(data) {
          this.response = data;
          this.mostrarResposta = true;
          this.campoInvalido = false;
        }
      });
    } else {
      this.campos.forEach(controlName => {
        if (!this.formulario?.get(controlName)?.value) {
          this.campoInvalido = true;
        }
      });
    }
  }

  adicionar(){
    const newControlName = 'campo-' + (this.campos.length + 1);
    const newControl = new FormControl('');
    this.formulario.addControl(newControlName, newControl);
    this.campos.push(newControlName);
    this.campoInvalido = false;
  }

  removerCampoDuplicado(controlName: string) {
    if (this.campos.length > 1) {
      this.formulario.removeControl(controlName);
      this.campos = this.campos.filter(c => c !== controlName);
    }
  }

  limparDados() {
    this.mostrarResposta = false;
    this.campos.forEach(controlName => this.formulario.removeControl(controlName));
    this.campos = ['campo1'];
    this.campoInvalido = false;
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
    return valores.filter(Boolean);
  }
  //#endregion

}
