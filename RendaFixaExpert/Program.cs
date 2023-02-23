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
do
{
    ZerarVariaveis();
    Console.WriteLine("");
    Console.WriteLine("################################");
    Console.WriteLine("Digite 1 - Quanto meus investimentos rendeu ?");
    Console.WriteLine("Digite 2 - Qual foi minha rentabilidade ?");
    Console.WriteLine("Digite 3 - Rentabilidade Acumulada entre periodos?");
    Console.WriteLine("Digite 4 - Sair ?");
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
            Console.WriteLine("Qual foi o seu ultimo valor investido ?");
            valorFormatadoValorAnterior = FormatadorDecimal(Console.ReadLine(), "N2");

            Console.WriteLine("Qual é o novo para ser investido valor ?");
            valorNovoInvestimento = FormatadorDecimal(Console.ReadLine(), "N2");

            if (decimal.TryParse(valorFormatadoValorAnterior, NumberStyles.Currency, culture, out valorDecimal1) && decimal.TryParse(valorNovoInvestimento, NumberStyles.Currency, culture, out valorDecimal2))
                Console.WriteLine($"Rentabilidade de : {CalcularTaxaRentabilidadeEntreDoisValores(valorDecimal1, valorDecimal2).ToString("0.#")}%");
            break;


        case "3":


        case "4":
            stopLoop = true;
            break;

        default:
            break;
    }
    i += 1;
} while (!stopLoop);

decimal CalcularTaxaRentabilidadeEntreDoisValores(decimal valorAnterior, decimal valorNovo) => ((valorNovo / valorAnterior) - 1) * 100;
decimal CalcularAcumuloTaxa(decimal valorInvestido, decimal taxaRendimento) => valorInvestido * (1 + (taxaRendimento / 100));
string FormatadorDecimal(string valor, string formato) => decimal.Parse(valor, culture).ToString(formato, culture);
void ZerarVariaveis()
{
    valorDecimal1 = 0;
    valorDecimal2 = 0;
    valorFormatadoTaxaRendimento = "";
    valorFormatadoValorAnterior = "";
    result = 0;
}