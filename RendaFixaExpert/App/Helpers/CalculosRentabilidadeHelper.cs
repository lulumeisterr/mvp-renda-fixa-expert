using RendaFixaExpert.Model;

namespace RendaFixaExpert.App.Helpers
{
    /// <summary>
    /// Metodos auxiliares para calculos de rentabilidade.
    /// </summary>
    public static class CalculosRentabilidadeHelper
    {

        /// <summary>
        /// Calcular rentabilidade diaria.
        /// </summary>
        /// <param name="valorInicial"></param>
        /// <param name="valorFinal"></param>
        /// <returns>rentabilidade</returns>
        public static Rentabilidade CalcularRentabilidadeDiaria(decimal valorInicial, decimal valorFinal)
        {
            return new Rentabilidade
            {
                ValorAportado = valorFinal,
                RentabilidadePorDia = ((valorFinal / valorInicial) - 1) * 100
            };
        }
    }
}
