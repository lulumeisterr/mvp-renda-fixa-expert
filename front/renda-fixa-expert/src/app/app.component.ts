import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `<app-menu></app-menu>   
             <main></main>
            <footer><p>&copy; 2023 - Todos os direitos reservados</p></footer>
            <router-outlet></router-outlet>`
})
export class AppComponent {
  title = 'renda-fixa-expert';
}
