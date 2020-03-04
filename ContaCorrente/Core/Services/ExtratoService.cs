using Core.Entities.Sql;
using Core.Exceptions;
using Core.Interfaces.Repositories.Sql;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ExtratoService : IExtratoService
    {
        private readonly IExtratoRepository _extratoRepositorio;

        public ExtratoService(IExtratoRepository extratoRepositorio)
        {
            _extratoRepositorio = extratoRepositorio;
        }

        public async Task<IEnumerable<Extrato>> HistoricoMovimentacoesAsync(int idConta)
        {
            return _extratoRepositorio.FindAsync(x => x.IdConta == idConta).Result.OrderByDescending(x => x.DataReferenica);
        }

        public async Task<Extrato> UltimaMovimentacaoAsync(int idConta)
        {
            var query = _extratoRepositorio.Query(x => x.IdConta == idConta);
            query = query.OrderBy(x => x.DataReferenica);

            return query.LastOrDefault();
        }
    }
}
