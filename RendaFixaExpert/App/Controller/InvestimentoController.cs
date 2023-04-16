using Microsoft.AspNetCore.Mvc;
using RendaFixaExpert.App.Controller.Request;
using RendaFixaExpert.App.Controller.Response;
using RendaFixaExpert.Model;
using RendaFixaExpert.Response;

namespace RendaFixaExpert.App.Controller
{
    /// <summary>
    /// Classe responsavel por receber a requisição e passar para a camada
    /// de presenters.
    /// </summary>

    [ApiController]
    [Route("api/[controller]")]
    public class InvestimentoController : ControllerBase
    {
        //Injeção de dependência.
        private readonly ICalculosInvestimentos _presenter;

        //Construtor
        public InvestimentoController(ICalculosInvestimentos presenter)
        {
            _presenter = presenter;
        }

        /// <summary>
        /// Identificar total de investimento a partir da taxa de rendimento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>CalcularAcumuloTaxaRendimentoAsync</returns>
        [HttpGet("/api/investimentos")]
        public async Task<IActionResult> CalcularAcumuloTaxaRendimentoAsync([FromQuery] CalcularAcumuloTaxaRendimentoRequest request)
        {
            decimal resultado = await _presenter.CalcularAcumuloTaxaRendimentoAsync(request.ValorInvestido, request.TaxaRendimento);
            var responseDto = new CalcularAcumuloTaxaRendimentoResponseDTO
            {
                AcumuloTaxaRendimento = resultado
            };
            return Ok(responseDto);
        }

        /// <summary>
        /// Calcular suas rentabilidades
        /// </summary>
        /// <param name="request"></param>
        /// <returns>CalcularAcumuloTaxaRendimentoAsync</returns>
        [HttpPost("/api/investimentos/rentabilidades")]
        public async IAsyncEnumerable<CalcularTaxaRentabilidadeResponseDTO> CalcularTaxaRentabilidadeAsync([FromBody] CalcularTaxaRentabilidadeRequest request)
        {
            Rentabilidade rentabilidade = new Rentabilidade { ListValorAportados = request.ListValorAportados };
            List<Rentabilidade> listaRentabilidade = await _presenter.CalcularTaxaRentabilidadeAsync(rentabilidade);

            foreach (Rentabilidade item in listaRentabilidade)
            {
                yield return new CalcularTaxaRentabilidadeResponseDTO
                {
                    Dias = item.Dias,
                    ValorAportado = item.ValorAportado,
                    RentabilidadePorDia = item.RentabilidadePorDia
                };
            }
        }
    }
}
