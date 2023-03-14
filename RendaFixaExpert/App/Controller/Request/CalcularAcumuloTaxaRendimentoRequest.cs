using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RendaFixaExpert.App.Controller.Request
{
     /// <summary>
     /// Classe responsavel por receber os dados requisitados para ser processados pela controller.
     /// </summary>
    public class CalcularAcumuloTaxaRendimentoRequest
    {
        /// <summary>
        ///  Valor investido
        /// </summary>
        public decimal ValorInvestido { get; set; }

        /// <summary>
        /// Taxa de rendimento
        /// </summary>
        public decimal TaxaRendimento { get; set; }
    }
}
