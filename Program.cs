// See https://aka.ms/new-consolIne-template for more information
using System.Globalization;

Console.WriteLine("Hello, World!");

var i = 1;
double valorAnterior = 0;
double valorNovo = 0;
double result = 0;
double taxaRendimento = 0;
do
{
    Console.WriteLine("");
    Console.WriteLine("################################");
    Console.WriteLine("Digite 1 - Quanto meus investimentos rendeu ?"); //Bubblesort //InsertionSort //MergeSort
    Console.WriteLine("Digite 2 - Qual foi minha rentabilidade ?");
    Console.WriteLine("Digite 3 - Qual minha rentabilidade rentabilidade acumulada ?");
    Console.WriteLine("Digite 4 - Sair ?");
    Console.WriteLine("################################");
    Console.WriteLine("");

    string item = Console.ReadLine();

    switch (item)
    {
        case "1":
            Console.WriteLine("Qual foi o seu valor investido ?");
            valorAnterior = (double)Convert.ToDecimal(Console.ReadLine(), new CultureInfo("pt-BR"));

            Console.WriteLine("Quantos % de rendimento");
            taxaRendimento = (double)Convert.ToDecimal(Console.ReadLine(), new CultureInfo("pt-BR"));
            result = valorAnterior * (1 + taxaRendimento);

            Console.WriteLine($"Você teve um valor acumulado de {result}");
            break;

        case "2":

            Console.WriteLine("Qual foi o seu valor investido ?");
            valorAnterior = (double)Convert.ToDecimal(Console.ReadLine(), new CultureInfo("pt-BR"));

            Console.WriteLine("Qual novo valor ?");
            valorNovo = (double)Convert.ToDecimal(Console.ReadLine(), new CultureInfo("pt-BR"));
            result = CalcularTaxaRentabilidadeEntreDoisValores(valorAnterior, valorNovo);

            Console.WriteLine($"Sua rentabilidade é de {result}%");
            break;

        case "3":

            Console.WriteLine($"Por quantos dias você quer saber sobre a sua rentabilidade acumulada ?");
            int dias = Int32.Parse(Console.ReadLine());
            int periodos = 1;
            Dictionary<int, double> valores = new Dictionary<int, double>();

            for (int j = 1; j < dias; j++)
            {
                if (!(periodos == 1))
                    if (periodos >= 2)
                        periodos++;


                if (j >= dias)
                {
                    break;
                }

                Console.WriteLine($"Qual foi o seu valor investido no {periodos} dia");
                valorAnterior = (double)Convert.ToDecimal(Console.ReadLine(), new CultureInfo("pt-BR"));

                Console.WriteLine($"Qual foi o seu valor investido no {(periodos)} dia");
                valorNovo = (double)Convert.ToDecimal(Console.ReadLine(), new CultureInfo("pt-BR"));

                if(!(j == 1))
                    valores.Add(j, CalcularTaxaRentabilidadeEntreDoisValores(valorAnterior, valorNovo));

                valorAnterior = valorNovo;

            }
            break;

        case "4":
            Console.WriteLine("Programa finalizado");
            i = -1;
            break;

        default:
            break;
    }
    i += 1;
} while (i >= 0);

double CalcularTaxaRentabilidadeEntreDoisValores(double valorAnterior, double valorNovo)
{
    return valorNovo / valorAnterior - 1;
}