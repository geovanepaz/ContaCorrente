using App.Interfaces;
using Core.Exceptions;
using Core.Interfaces.Repositories.Sql;
using Core.Interfaces.Services;
using Core.ViewModels.ContaCorrente;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class ResgateSaldoAppService : IResgateSaldoAppService
    {
        private readonly IExtratoService _extratoservice;
        private readonly IResgateSaldoService _resgateSaldoService;
        public ResgateSaldoAppService(IExtratoService extratoservice, IResgateSaldoService resgateSaldoService)
        {
            _extratoservice = extratoservice;
            _resgateSaldoService = resgateSaldoService;
        }

        public async Task<ResgateResponse> ResgatarAsync(ResgateRequest resgate)
        {
            var ultimaMovimentacao = await _extratoservice.UltimaMovimentacaoAsync(resgate.IdConta);

            if (ultimaMovimentacao == null)
            {
                throw new BadRequestException("Conta inexistente, bloqueada ou sem movimentação");
            }

            var extratoResgate = _resgateSaldoService.Resgatar(ultimaMovimentacao);
            var resgateResponse = new ResgateResponse
            {
                ValorSacado = extratoResgate.Valor,
                Saldo = extratoResgate.SaldoAtual,
            };

            return resgateResponse;
        }
    }
}