using RendaFixaExpert.App.Helpers;
using RendaFixaExpert.Model;
using RendaFixaExpert.Response;

namespace RendaFixaExpert.App.Presenters
{
    public class InvestimentoPresenterServices : ICalculosInvestimentos
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public InvestimentoPresenterServices()
        {
        }

        /// <summary>
        /// Metodo responsavel por retornar o acumulo do investimento a partir da taxa de rendimento
        /// </summary>
        /// <param name="valorInvestido">Valor investido</param>
        /// <param name="taxaRendimento">Taxa de rendimento</param>
        /// <returns>CalcularAcumuloTaxaRendimentoAsync</returns>
        public async Task<decimal> CalcularAcumuloTaxaRendimentoAsync(decimal valorInvestido, decimal taxaRendimento) => await Task.FromResult(valorInvestido * (1m + (taxaRendimento / 100m)));


        /// <summary>
        /// Metodo responsavel por calcular a rentabilidade entre dois valores.
        /// </summary>
        /// <param name="rentabilidadeRequest"></param>
        /// <returns>CalcularTaxaRentabilidadeAsync</returns>
        public async Task<List<Rentabilidade>> CalcularTaxaRentabilidadeAsync(CalcularTaxaRentabilidadeRequest rentabilidadeRequest)
        {
            List<Rentabilidade> listaRentabilidade = new List<Rentabilidade>();
            Rentabilidade rentabilidade = new Rentabilidade();

            int auxDias = 1;
    
            if (rentabilidadeRequest.ListValorAportados != null && rentabilidadeRequest.ListValorAportados.Count >= 2)
            {
                rentabilidade = new Rentabilidade
                {
                    Dias = 1,
                    ValorAportado = rentabilidadeRequest.ListValorAportados[0],
                    RentabilidadePorDia = 0
                };

                listaRentabilidade.Add(rentabilidade);

                foreach (var valorAportado in rentabilidadeRequest.ListValorAportados.Skip(1))
                {
                    rentabilidade = CalculosRentabilidadeHelper.CalcularRentabilidadeDiaria(listaRentabilidade.Last().ValorAportado, valorAportado);
                    rentabilidade.Dias = ++auxDias;
                    listaRentabilidade.Add(rentabilidade);
                }
            }
            return await Task.FromResult(listaRentabilidade);
        }
    }
}
