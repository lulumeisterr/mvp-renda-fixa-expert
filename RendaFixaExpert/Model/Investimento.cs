using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RendaFixaExpert.Model
{
    /// <summary>
    /// Classe resposavel por capturar os valore associativos de investimentos
    /// </summary>
    public class Investimento
    {
        /// <summary>
        /// Valor investido
        /// </summary>
        public decimal ValorInvestido { get; set; }

        /// <summary>
        /// Taxa de rendimento
        /// </summary>
        public decimal TaxaRendimento { get; set; }
    }
}
