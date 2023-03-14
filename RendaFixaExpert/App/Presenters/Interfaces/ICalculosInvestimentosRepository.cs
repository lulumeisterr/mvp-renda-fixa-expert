using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RendaFixaExpert.App.Presenters.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICalculosInvestimentosRepository
    {
        /// <summary>
        /// Calcular taxa de rentabilidade entre dois valores
        /// </summary>
        /// <param name="valorJaAportado">Valor ja aportado</param>
        /// <param name="valorNovo">Novo valor a ser verificado a rentabilidade</param>
        /// <returns>CalcularTaxaRentabilidade</returns>
        Task<decimal> CalcularTaxaRentabilidadeAsync(decimal valorNovo, decimal valorJaAportado);

        /// <summary>
        /// Identificar total de investimento a partir da taxa de rendimento.
        /// </summary>
        /// <param name="valorInvestido">Valor investido</param>
        /// <param name="taxaRendimento">taxa de rendimento</param>
        /// <returns>CalcularAcumuloTaxa</returns>
        Task<decimal> CalcularAcumuloTaxaRendimentoAsync(decimal valorInvestido, decimal taxaRendimento);
    }
}
