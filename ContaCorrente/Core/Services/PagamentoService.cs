using Core.Entities.Sql;
using Core.Exceptions;
using Core.Interfaces.Repositories.Sql;
using Core.Interfaces.Services;
using Core.ViewModels.ContaCorrente;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IExtratoRepository _extratoRepositorio;
        private readonly IComprovantePagamentoRepository _comprovantePagamentoRepositorio;

        public PagamentoService(IExtratoRepository extratoRepositorio, IComprovantePagamentoRepository registroPagamentoRepositorio)
        {
            _extratoRepositorio = extratoRepositorio;
            _comprovantePagamentoRepositorio = registroPagamentoRepositorio;
        }

        public async Task<Extrato> PagarAsync(Extrato ultimaMovimentacao, decimal valorPagamento, string codigoBarras)
        {
            if (ultimaMovimentacao.SaldoAtual < valorPagamento)
            {
                throw new BadRequestException("Saldo Insuficiente");
            }

            var jaPago = _comprovantePagamentoRepositorio.FindAsync(x => x.CodigoBarras == codigoBarras).Result.Any();
            if (jaPago)
            {
                throw new BadRequestException("Código de barras consta como pago.");
            }

            var extrato = new Extrato
            {
                DataReferenica = DateTime.Now,
                IdConta = ultimaMovimentacao.IdConta,
                TipoOperacao = "pagamento",
                SaldoAtual = ultimaMovimentacao.SaldoAtual - valorPagamento,
                Valor = valorPagamento,
            };
            return await _extratoRepositorio.InsertAsync(extrato);
        }

        public async Task<ComprovantePagamento> SalvarComprovanteAsync(ComprovantePagamento comprovante)
        {
            return await _comprovantePagamentoRepositorio.InsertAsync(comprovante);
        }
    }
}
