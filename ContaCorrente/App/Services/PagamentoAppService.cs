using Core.Entities.Sql;
using Core.Exceptions;
using Core.Interfaces.Services;
using Core.ViewModels.ContaCorrente;
using System.Threading.Tasks;

namespace App.Interfaces
{
    public class PagamentoAppService : IPagamentoAppService
    {
        private readonly IExtratoService _extratoService;
        private readonly IPagamentoService _pagamentoService;
        public PagamentoAppService(IExtratoService extratoService, IPagamentoService pagamentoService)
        {
            _extratoService = extratoService;
            _pagamentoService = pagamentoService;
        }

        public async Task<PagamentoResponse> PagarAsync(PagamentoRequest pagamento)
        {
            var ultimaMovimentacao = await _extratoService.UltimaMovimentacaoAsync(pagamento.IdContaCedente);
            if (ultimaMovimentacao == null)
            {
                throw new BadRequestException("Conta inexistente, bloqueada ou sem movimentação");
            }

            var extratoPagamento = await _pagamentoService.PagarAsync(ultimaMovimentacao, pagamento.ValorPagamento, pagamento.DadosPagamento.CodigoBarras);
            var comprovante = MontarComprovante(extratoPagamento.Id, pagamento.DadosPagamento);

            await _pagamentoService.SalvarComprovanteAsync(comprovante);
            return MontarPagamentoResponse(comprovante, extratoPagamento.Valor);
        }

        private ComprovantePagamento MontarComprovante(int IdExtrato, DadosPagamento dadosPagamento)
        {
            return new ComprovantePagamento
            {
                IdExtrato = IdExtrato,
                CodigoBarras = dadosPagamento.CodigoBarras,
                Destinatario = dadosPagamento.NomeBeneficiario,
                Valor = dadosPagamento.ValorConta,
            };
        }

        private PagamentoResponse MontarPagamentoResponse(ComprovantePagamento registro, decimal valorPago)
        {
            return new PagamentoResponse
            {
                CodigoDeBarras = registro.CodigoBarras,
                NomeBeneficiario = registro.Destinatario,
                ValorConta = registro.Valor,
                ValorPago = valorPago
            };
        }
    }
}