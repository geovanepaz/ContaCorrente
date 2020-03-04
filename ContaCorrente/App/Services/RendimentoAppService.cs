using AutoMapper;
using Core.Entities.Sql;
using Core.Exceptions;
using Core.Interfaces.Services;
using Core.ViewModels.ContaCorrente;
using Cross.Util.Extensions;
using System.Threading.Tasks;

namespace App.Interfaces
{
    public class RendimentoAppService : IRendimentoAppService
    {
        private readonly IExtratoService _extratoService;
        private readonly IRendimentoService _rendimentoService;
        private readonly IMapper _mapper;

        public RendimentoAppService(IExtratoService extratoService, IRendimentoService rendimentoService, IMapper mapper)
        {
            _extratoService = extratoService;
            _rendimentoService = rendimentoService;
            _mapper = mapper;
        }

        public async Task<ExtratoResponse> AplicarCorrecaoMonetariaAsync(RendimentoRequest rendimento)
        {
            var ultimaMovimentacao = await _extratoService.UltimaMovimentacaoAsync(rendimento.IdConta);

            if (ultimaMovimentacao == null)
            {
                throw new BadRequestException("Conta inexistente, bloqueada ou sem movimentação");
            }

            var extratoRendimento = await _rendimentoService.AplicarCorrecaoMonetariaAsync(ultimaMovimentacao.SaldoAtual, rendimento.PercentualRendimento, rendimento.IdConta);

            return extratoRendimento.MapTo<ExtratoResponse>(_mapper); ;
        }
    }
}