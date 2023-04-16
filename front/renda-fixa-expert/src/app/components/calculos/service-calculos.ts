import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, tap, throwError } from "rxjs";

/**
 * Ao criar uma classe em Angular que funciona como um serviço, 
  você geralmente usa o decorator @Injectable. Esse decorator é usado para indicar que a classe pode ser injetada 
  com dependências, como outros serviços ou instâncias de classe.

 *Quando uma classe é marcada com @Injectable, o Angular criará uma única instância da classe para 
  todo o aplicativo e a disponibilizará para outros componentes e serviços que a solicitem por meio da injeção de dependência.
 */
@Injectable({
  providedIn: 'root'
})
export class CalculoService {

  private port : number = 64371;
  private urlBase : string = `https://localhost:${this.port}/api/investimentos`;
  constructor(private http: HttpClient) { }

  /**
   * 
   * @returns 
   */
  getAcumuloInvestimento(body : any) : Observable<any> {
    return this.http.post<any>(`${this.urlBase}/rentabilidades`,body)
    .pipe(tap(data => console.log(data)),
    catchError(this.handleError)
    );
  }

  private handleError(error: any) {
    console.error(error);
    return throwError('Algo deu errado. Tente novamente mais tarde.');
  }
  
}
