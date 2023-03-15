using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RendaFixaExpert.Model;

namespace RendaFixaExpert.Model
{
    /// <summary>
    /// Classe modelo que representam os dados que serão manipulados
    /// </summary>
    public class Investimento
    {
        /// <summary>
        /// Valor a ser investido
        /// </summary>
        public decimal ValorInvestido { get; set; }

        /// <summary>
        /// Taxa de rendimento
        /// </summary>
        public decimal TaxaRendimento { get; set; }

        /// <summary>
        /// Rentabilidade do seu investimento
        /// </summary>
        public Rentabilidade? Rentabilidade { get; set; }
    }
}
