using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using RendaFixaExpert.App.Presenters.Interfaces;
using RendaFixaExpert.Model;

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
        public async Task<List<Rentabilidade>> CalcularTaxaRentabilidadeAsync(Rentabilidade rentabilidadeRequest)
        {
            List<Rentabilidade> listaRentabilidade = new List<Rentabilidade>();
            int dias = rentabilidadeRequest.Dias;
            Rentabilidade rentabilidade = new Rentabilidade();

            if (dias > 0 && rentabilidadeRequest.ListValorAportados != null && rentabilidadeRequest.ListValorAportados.Count >= 2)
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
                    rentabilidade = CalcularRentabilidade(dias, listaRentabilidade.Last().ValorAportado, valorAportado);
                    listaRentabilidade.Add(rentabilidade);
                }
            }
            return await Task.FromResult(listaRentabilidade);
        }

        #region Calcular rentabilidade
        private Rentabilidade CalcularRentabilidade(int dias, decimal valorInicial, decimal valorFinal)
        {
            return new Rentabilidade
            {
                Dias = dias++,
                ValorAportado = valorFinal,
                RentabilidadePorDia = ((valorFinal / valorInicial) - 1) * 100
            };
        }
        #endregion
    }
}
