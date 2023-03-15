// See https://aka.ms/new-consolIne-template for more information

using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using RendaFixaExpert.App.Presenters;
using RendaFixaExpert.App.Presenters.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x => { x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });

//Configuração de injeção de dependencias.
builder.Services.AddTransient<ICalculosInvestimentos, InvestimentoPresenterServices>();

//add no pipeline de serviço da aplicação.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Renda fixa expert", Version = "v1" });
});

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>{endpoints.MapControllers();});

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Investimentos - API");
    c.RoutePrefix = string.Empty;
});

app.Run();
/*
CultureInfo culture = CultureInfo.GetCultureInfo("pt-BR");

var i = 1;
bool stopLoop = false;
decimal result = 0m;
decimal valorDecimal1, valorDecimal2 = 0;
string valorFormatadoValorAnterior = "";
string valorNovoInvestimento = "";
string valorFormatadoTaxaRendimento = "";
Dictionary<int, decimal> rentabilidadePorPeriodo = new Dictionary<int, decimal>();
do
{
    ZerarVariaveis();
    Console.WriteLine("");
    Console.WriteLine("################################");
    Console.WriteLine("Digite 1 - Quanto meus investimentos rendeu ?");
    Console.WriteLine("Digite 2 - Calcular minhas rentabilidades ?");
    Console.WriteLine("Digite 3 - Calcular meus aportes mensais ?");
    Console.WriteLine("Digite 4 - Como saber a taxa anual em meses/dias ?");
    Console.WriteLine("Digite 5 - Sair ?");
    Console.WriteLine("################################");
    Console.WriteLine("");


    string item = Console.ReadLine();
    switch (item)
    {
        case "1":
            Console.WriteLine("Qual foi o seu valor investido ?");
            valorFormatadoValorAnterior = FormatadorDecimal(Console.ReadLine(), "N2");

            Console.WriteLine("Quantos % de rendimento");
            valorFormatadoTaxaRendimento = FormatadorDecimal(Console.ReadLine(), "N2");

            if (decimal.TryParse(valorFormatadoValorAnterior, NumberStyles.Currency, culture, out valorDecimal1) && decimal.TryParse(valorFormatadoTaxaRendimento, NumberStyles.Currency, culture, out valorDecimal2))
                Console.WriteLine($"Valor acumulado : {CalcularAcumuloTaxa(valorDecimal1, valorDecimal2).ToString("C2", culture)}");
            break;

        case "2":

            decimal rentabilidadeAcumulada = 1;
            decimal valorAntigo, valorNovo, resultado;
            List<string> periodos = new List<string>();

            Console.WriteLine("Você quer ver/comparar sua rentabilidade de quantos dias ?");
            var dias = int.Parse(Console.ReadLine());

            AdicionandoPeriodos(dias, ref periodos);

            for (int g = 1; g < periodos.Count; g++)
            {
                if (g == 1)
                {
                    valorAntigo = decimal.Parse(periodos[g - 1]);
                    valorNovo = decimal.Parse(periodos[g]);
                    resultado = CalcularTaxaRentabilidadeEntreDoisValores(valorAntigo, valorNovo);
                    rentabilidadePorPeriodo.Add(g, resultado);
                    continue;
                }
                valorAntigo = decimal.Parse(periodos[g - 1]);
                valorNovo = decimal.Parse(periodos[g]);

                resultado = CalcularTaxaRentabilidadeEntreDoisValores(valorAntigo, valorNovo);
                rentabilidadePorPeriodo.Add(g, resultado);
            }

            for (int j = 1; j < rentabilidadePorPeriodo.ToList().Count; j++)
            {
                rentabilidadeAcumulada = CalcularRentabilidadeAcumuladaTodosPeriodos(rentabilidadePorPeriodo, j);
            }

            // Cabecalho
            Console.WriteLine($"{PadRight("Dias", 15)}{PadRight("Valor", 15)}{PadRight("Rentabilidade", 15)}");
            var dictWithIndex = rentabilidadePorPeriodo.Select((item, index) => new { Index = index, Key = item.Key, Value = item.Value });

            // Exibir os valores em loop
            foreach (var rentabilidade in dictWithIndex)
            {
                Console.WriteLine($"{PadRight($"{rentabilidade.Key}", 15)}{PadRight($"{periodos[rentabilidade.Index]}", 15)}{PadRight($"{rentabilidade.Value.ToString("0.#")}%", 15)}");
            }
            Console.WriteLine($"Rentabilidade acumulada de todos os periodos adicionados: {rentabilidadeAcumulada.ToString("0.#")}%");
            break;

        case "3":

            double calculo = 0;

            Dictionary<string, double> mesesDict = new Dictionary<string, double>();

            Console.WriteLine($"Por quantos meses você pensa em investir ?");
            var meses = int.Parse(Console.ReadLine());

            Console.WriteLine($"Valor inicial de investimento ?");
            var valorInicial = int.Parse(Console.ReadLine());

            Console.WriteLine($"Adicione aqui a taxa de rendimento ?");
            var taxaRendimento = int.Parse(Console.ReadLine());

            for (int mesesIndex = 0; mesesIndex < meses; mesesIndex++)
            {
                if (mesesIndex == 0)
                {
                    mesesDict.Add(ListaComMesesDoAno()[mesesIndex], valorInicial);
                    continue;
                }

                if (mesesIndex == 1)
                {
                    calculo = (1 + (taxaRendimento / 100.0)) * mesesDict.Values.ToList()[mesesIndex - 1] + valorInicial;
                    mesesDict.Add(ListaComMesesDoAno()[mesesIndex], calculo);
                    continue;
                }

                calculo = (1 + (taxaRendimento / 100.0)) * mesesDict.Values.ToList()[mesesIndex - 1];

                string mesAtual = ListaComMesesDoAno()[mesesIndex];
                mesesDict.Add(mesAtual, calculo);
            }

            foreach (KeyValuePair<string, double> keyValuePair in mesesDict)
            {
                Console.WriteLine($"Mês {keyValuePair.Key} - Valor {keyValuePair.Value:C}");
            }

            break;

        case "4":

            Console.WriteLine($"Digite D Para dia e M para Mes");
            string input = Console.ReadLine();

            if (!(input.ToUpper() == "D") && !(input.ToUpper() == "M"))
                break;
    
            Console.WriteLine($"Digite o valor da taxa anual");
            string taxaAnual = FormatadorDecimal(Console.ReadLine(), "N2");

            double valor = 0;
            int periodosInput = input == "D" ? periodosInput = 257 : 12;
            if (double.TryParse(taxaAnual, NumberStyles.Currency, culture, out valor))
            {
                double x = CalcularValorTaxaAnualPorPeriodos(valor, periodosInput);
                Console.WriteLine($"A taxa de {(valor / 100)}% em {(input == "D" ? "Dias" : "Meses")} é {Math.Abs(x / 100)}%");
            }
            break;

        case "5":
            stopLoop = true;
            break;

        default:
            break;
    }
    i += 1;
} while (!stopLoop);

double  CalcularValorTaxaAnualPorPeriodos(double valor, int periodo) => Math.Pow(1 + valor / 100, 1.0 / periodo) - 1;
decimal CalcularTaxaRentabilidadeEntreDoisValores(decimal valorAnterior, decimal valorNovo) => ((valorNovo / valorAnterior) - 1) * 100;
decimal CalcularAcumuloTaxa(decimal valorInvestido, decimal taxaRendimento) => valorInvestido * (1 + (taxaRendimento / 100));
decimal CalcularRentabilidadeAcumuladaTodosPeriodos(Dictionary<int, decimal> rentabilidadePorPeriodo, int j)
{
    decimal rentabilidadeAcumulada;
    var x = (rentabilidadePorPeriodo.Values.ToList()[j - 1] * rentabilidadePorPeriodo.Values.ToList()[j] + 1) - 1;
    rentabilidadeAcumulada = Math.Abs(x);
    return rentabilidadeAcumulada;
}

string FormatadorDecimal(string valor, string formato) => decimal.Parse(valor, culture).ToString(formato, culture);

void AdicionandoPeriodos(int dias,ref List<string> periodos)
{
    var aux = 1;
    for (int i = 0; i < dias; i++)
    {
        if (i >= aux)
            aux = i + 1;
        Console.WriteLine($"Adicione o {aux}º valor ?");
        var valor = FormatadorDecimal(Console.ReadLine(), "N2");
        periodos.Add(valor);
    }
}
// Função para preencher uma string com espaços à direita para atingir a largura especificada
static string PadRight(string input, int width) => input.PadRight(width, ' ');

void ZerarVariaveis()
{
    valorDecimal1 = 0;
    valorDecimal2 = 0;
    valorFormatadoTaxaRendimento = "";
    valorFormatadoValorAnterior = "";
    result = 0;
    rentabilidadePorPeriodo = new Dictionary<int, decimal>();
}

List<string> ListaComMesesDoAno()
{
    List<string> meses = new List<string>();
    for (int i = 1; i <= 12; i++)
    {
        meses.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(i));
    }
    return meses;
}
*/