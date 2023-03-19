namespace RendaFixaExpert.Model
{
    /// <summary>
    /// Rentabilidade do investimento
    /// </summary>
    public class Rentabilidade
    {
        /// <summary>
        /// Valor antigo.
        /// </summary>
        public List<decimal>? ListValorAportados { get; set; }

        /// <summary>
        /// Valor antigo.
        /// </summary>
        public decimal ValorAportado { get; set; }

        /// <summary>
        /// RentabilidadePorDia
        /// </summary>
        public decimal RentabilidadePorDia { get; set; }

        /// <summary>
        /// Data Inicio investimento
        /// </summary>
        public DateTime DataInicio { get; set; }

        /// <summary>
        /// Data fim investimendo
        /// </summary>
        public DateTime DataFim{ get; set; }

        /// <summary>
        /// Dias investidos
        /// </summary>
        public int Dias { get; set; }
    }
}