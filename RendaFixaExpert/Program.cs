// See https://aka.ms/new-consolIne-template for more information
using System.Drawing;
using System.Globalization;

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
    Console.WriteLine("Digite 3 - Sair ?");
    Console.WriteLine("################################");
    Console.WriteLine("");


    string item = Console.ReadLine();
    switch (item)
    {
        case "1":
            Console.WriteLine("Qual foi o seu valor investido ?");
            valorFormatadoValorAnterior = FormatadorDecimal(Console.ReadLine(),"N2");

            Console.WriteLine("Quantos % de rendimento");
            valorFormatadoTaxaRendimento = FormatadorDecimal(Console.ReadLine(),"N2");

            if (decimal.TryParse(valorFormatadoValorAnterior, NumberStyles.Currency, culture, out valorDecimal1) && decimal.TryParse(valorFormatadoTaxaRendimento, NumberStyles.Currency, culture, out valorDecimal2))
                Console.WriteLine($"Valor acumulado : {CalcularAcumuloTaxa(valorDecimal1, valorDecimal2).ToString("C2", culture)}");
            break;

        case "2":

            decimal rentabilidadeAcumulada = 1;
            decimal valorAntigo, valorNovo, resultado;
            List<string> periodos  = new List<string>();

            Console.WriteLine("Você quer ver/comparar sua rentabilidade de quantos dias ?");
            var dias = int.Parse(Console.ReadLine());

            AdicionandoPeriodos(dias,ref periodos);

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
            stopLoop = true;
            break;

        default:
            break;
    }
    i += 1;
} while (!stopLoop);

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
