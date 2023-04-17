using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RendaFixaExpert.Model;
using RendaFixaExpert.Response;

namespace RendaFixaExpert.App.Presenters.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICalculosInvestimentos
    {
        /// <summary>
        /// Calcular taxa de rentabilidade entre dois valores
        /// </summary>
        /// <param name="rentabilidadeRequest">Rentabilidade</param>
        /// <returns>CalcularTaxaRentabilidade</returns>
        Task<List<Rentabilidade>> CalcularTaxaRentabilidadeAsync(CalcularTaxaRentabilidadeRequest rentabilidadeRequest);

        /// <summary>
        /// Identificar total de investimento a partir da taxa de rendimento.
        /// </summary>
        /// <param name="valorInvestido">Valor investido</param>
        /// <param name="taxaRendimento">taxa de rendimento</param>
        /// <returns>CalcularAcumuloTaxa</returns>
        Task<decimal> CalcularAcumuloTaxaRendimentoAsync(decimal valorInvestido, decimal taxaRendimento);
    }
}
