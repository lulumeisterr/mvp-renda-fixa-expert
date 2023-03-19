namespace RendaFixaExpert.App.Helpers
{
    /// <summary>
    /// Metodos auxiliares para compor logicas.
    /// </summary>
    public static class CalculosGenericosHelper
    {
        /// <summary>
        /// Metodo responsavel por retornar a diferença entre datas
        /// </summary>
        /// <param name="dataInicio">dataInicio</param>
        /// <param name="dataFim">dataFim</param>
        /// <returns>Dias</returns>
        public static int CalcularDiferencaEntreDatas(DateTime? dataInicio, DateTime? dataFim)
        {
            if (!dataInicio.HasValue || !dataFim.HasValue) 
                throw new ArgumentException("Campos de data não podem ser nulos ou vazios");
            TimeSpan? diferenca = dataInicio - dataFim;
            return diferenca.Value.Duration().Days;
        }
    }
}
