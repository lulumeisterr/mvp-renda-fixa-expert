# renda-fixa-expert-c#
  Aprendendo conceitos e calculos de renda fixa por meio de programação
  
# Padrão de projeto.

  MVP (Model-View-Presenter) Padrão arquitetural de software que separa a lógica de apresentação do modelo de dados.
  
  
                   +------------------+
                   |     Controller   | --------|
                   +------------------+         |
                                                |
                                                |
                                                v
    +-----------------+          +-----------------+
    |      Model      |          |    Presenter    |
    +-----------------+          +-----------------+
    |                 | <---->   |                 |
    |    Data Access  |          |   Business Logic|
    |                 | <---->   |      Methods    |
    +-----------------+          +-----------------+

Controller é responsável por receber as requisições HTTP e encaminhar os dados para o Presenter. 

O Presenter é responsável por receber esses dados do Controller, processá-los utilizando a lógica de negócios e retornar as informações para a View. A View, por sua vez, é responsável por renderizar os dados recebidos pelo Presenter para serem exibidos ao usuário.

O Model é responsável por representar os dados da aplicação e o acesso a eles é feito através da camada de Data Access, que é responsável por fazer as operações de leitura e gravação desses dados. O Presenter utiliza as informações do Model para realizar as operações de negócios necessárias.


 # MVP VS MVC
   - MVC coloca a responsabilidade do processamento da requisição no Controlador, que é responsável por orquestrar a lógica de negócio e coordenar a comunicação entre a View e o Model. 
  - MVP coloca a responsabilidade no Presenter, que é responsável por comunicar-se com o Model e atualizar a View.
