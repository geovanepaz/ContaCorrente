using App.Interfaces;
using AutoMapper;
using Core.Exceptions;
using Core.Interfaces.Repositories.Sql;
using Core.Interfaces.Services;
using Core.ViewModels.ContaCorrente;
using Cross.Util.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class DepositoAppService : IDepositoAppService
    {
        private readonly IContaRepository _contaRepositorio;
        private readonly IDepositarService _depositarService;
        private readonly IExtratoService _extratoService;
        private readonly IMapper _mapper;

        public DepositoAppService(IContaRepository contaRepositorio, IDepositarService depositarService, IExtratoService extratoService, IMapper mapper)
        {
            _contaRepositorio = contaRepositorio;
            _depositarService = depositarService;
            _extratoService = extratoService;
            _mapper = mapper;
        }

        public async Task<object> DepositarAsync(DepositoRequest deposito)
        {
            var existeConta = _contaRepositorio.Query(x => x.Id == deposito.IdConta).Any();
            if (!existeConta)
            {
                throw new BadRequestException("Conta inexistente.");
            }

            var ultimaMovimentacao = await _extratoService.UltimaMovimentacaoAsync(deposito.IdConta);
            decimal saltoAtual = ultimaMovimentacao == null ? 0 : ultimaMovimentacao.SaldoAtual;

            var extratoDeposito = await _depositarService.DepositarAsync(saltoAtual, deposito.ValorDeposito, deposito.IdConta);
            return extratoDeposito.MapTo<ExtratoResponse>(_mapper);
        }
    }
}