using App.Interfaces;
using Core.ViewModels.ContaCorrente;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/contacorrente")]
    public class ContaCorrenteController : Controller
    {
        private readonly IExtratoAppService _extrato;
        private readonly IResgateSaldoAppService _resgateSaldo;
        private readonly IDepositoAppService _deposito;
        private readonly IPagamentoAppService _pagamento;
        private readonly IRendimentoAppService _rendimento;

        public ContaCorrenteController(IExtratoAppService extrato, IResgateSaldoAppService resgateSaldo, IDepositoAppService deposito, IPagamentoAppService pagamento, IRendimentoAppService rendimento)
        {
            _extrato = extrato;
            _resgateSaldo = resgateSaldo;
            _deposito = deposito;
            _pagamento = pagamento;
            _rendimento = rendimento;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ExtratoResponse>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [Route("{idConta}/extratos")]
        public async Task<IActionResult> SolicitarExtratosAsync(int idConta) => Ok(await _extrato.SolicitarAsync(idConta));

        [HttpPost]
        [ProducesResponseType(typeof(List<ResgateResponse>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [Route("saldo/resgates")]
        public async Task<IActionResult> ResgatarSaldoAsync([FromBody] ResgateRequest resgate) => Ok(await _resgateSaldo.ResgatarAsync(resgate));

        [HttpPost]
        [ProducesResponseType(typeof(List<object>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [Route("depositos")]
        public async Task<IActionResult> DepositarAsync([FromBody] DepositoRequest deposito) => Ok(await _deposito.DepositarAsync(deposito));

        [HttpPost]
        [ProducesResponseType(typeof(List<PagamentoResponse>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [Route("pagamentos")]
        public async Task<IActionResult> PagarAsync([FromBody] PagamentoRequest pagamento) => Ok(await _pagamento.PagarAsync(pagamento));

        [HttpPost]
        [ProducesResponseType(typeof(List<ExtratoResponse>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [Route("rendimentos")]
        public async Task<IActionResult> CorrecaoMonetariaAsync([FromBody] RendimentoRequest rendimento) => Ok(await _rendimento.AplicarCorrecaoMonetariaAsync(rendimento));
    }
}