# RendaFixaExpert

# Data bind
reponsavel por conecta dados entre a camada de visualização (template) 
e a camada de lógica (componente) de um aplicativo Angular que após um evento ou uma renderização a interpolação sera consumida. 
  
  Tipos de data bind
  
  - Interpolation : Interpolação de textos que permite conecta dados entre a camada de visualização
    ```html
        <input {{nome}} type="text"</input>
    ```

    ```javascript
        public nome : string = "Lucas";
    ```
 
- Property bind : Permite vincular/encapsular valores de propriedades de componentes a atributos de elementos HTML. Isso significa que, quando o valor da propriedade do componente muda, o valor do atributo HTML é atualizado de forma encapsulada. 
  
    ```html
        <input [disabled]="valoresDaCamadaVisualizacao" type="text"</input>
    ```

    ```javascript
       public valoresDaCamadaVisualização : boolean = false;
    ```
 
 - Event bind : Eventos que permite escutar e receber ações dos usuarios com a utilização de (onClick,onChanges etc..)
    ```html
        <input (changes)="verificarInputDesabilitado()" [disabled]="valoresDaCamadaVisualizacao" type="text"</input>
    ```
 
- Two-way data binding : possui a habilidade de fazer interações dinamicas entre a camda logica e a camada de visualização de forma reativa.
  
  ```html
    <input [(ngModel)]="desabilitarInput" type="text"</input>
  ```
  
  Se a propriedade desabilitarInput passar a ser true, automaticamente o angular se responsabilidade de atualizar o valor de forma reativa.
    ```javascript
     public desabilitarInput : boolean = false;
  ```
  
