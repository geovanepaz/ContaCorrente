using AutoMapper;
using Core.Exceptions;
using Core.Interfaces.Services;
using Core.ViewModels.ContaCorrente;
using Cross.Util.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Interfaces
{
    public class ExtratoAppService : IExtratoAppService
    {
        private readonly IExtratoService _extratoservice;
        private readonly IMapper _mapper;
        public ExtratoAppService(IExtratoService extratoservice, IMapper mapper)
        {
            _extratoservice = extratoservice;
            _mapper = mapper;
        }

        public async Task<List<ExtratoResponse>> SolicitarAsync(int idConta)
        {
            var historicoMovimentacao = await _extratoservice.HistoricoMovimentacoesAsync(idConta);

            if (!historicoMovimentacao.Any())
            {
                throw new NotFoundException();
            }

            return historicoMovimentacao.MapTo<List<ExtratoResponse>>(_mapper);
        }
    }
}