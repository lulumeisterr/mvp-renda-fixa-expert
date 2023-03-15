﻿namespace RendaFixaExpert.Model
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
        /// Dias a ser rendidos
        /// </summary>
        public int Dias { get; set; }
    }
}