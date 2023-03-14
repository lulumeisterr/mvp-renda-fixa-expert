using Microsoft.AspNetCore.Mvc;
using RendaFixaExpert.App.Controller.Request;
using RendaFixaExpert.App.Controller.Response;
using RendaFixaExpert.App.Presenters.Interfaces;

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
        [HttpGet]
        public async Task<IActionResult> CalcularAcumuloTaxaRendimentoAsync([FromQuery] CalcularAcumuloTaxaRendimentoRequest request)
        {
            decimal resultado = await _presenter.CalcularAcumuloTaxaRendimentoAsync(request.ValorInvestido, request.TaxaRendimento);
            var responseDto = new CalcularAcumuloTaxaRendimentoResponseDTO
            {
                AcumuloTaxaRendimento = resultado
            };
            return Ok(responseDto);
        }

    }
}
