using Core.Entities.Sql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IExtratoService
    {
        Task<Extrato> UltimaMovimentacaoAsync(int idConta);
        Task<IEnumerable<Extrato>> HistoricoMovimentacoesAsync(int idConta);
    }
}