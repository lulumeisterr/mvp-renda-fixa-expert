using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RendaFixaExpert.App.Presenters.Interfaces;

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
        /// <param name="valorNovo"></param>
        /// <param name="valorJaAportado"></param>
        /// <returns>CalcularTaxaRentabilidadeAsync</returns>
        public async Task<decimal> CalcularTaxaRentabilidadeAsync(decimal valorNovo, decimal valorJaAportado) => await Task.FromResult(((valorNovo / valorJaAportado) - 1) * 100);
    }
}
