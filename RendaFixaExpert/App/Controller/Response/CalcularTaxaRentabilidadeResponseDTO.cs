using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RendaFixaExpert.Model;

namespace RendaFixaExpert.Response
{
    /// <summary>
    /// Classe modelo que representam os dados que serão manipulados
    /// </summary>
    public class CalcularTaxaRentabilidadeResponseDTO
    {
        /// <summary>
        /// Valor antigo.
        /// </summary>
        public decimal ValorAportado { get; set; }

        /// <summary>
        /// RentabilidadePorDia
        /// </summary>
        public decimal RentabilidadePorDia { get; set; }

        /// <summary>
        /// Dias a ser rendidos
        /// </summary>
        public int Dias { get; set; }
    }
}
