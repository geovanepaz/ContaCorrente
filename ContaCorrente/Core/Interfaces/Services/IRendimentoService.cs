using Core.Entities.Sql;
using System;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IRendimentoService
    {
        Task<Extrato> AplicarCorrecaoMonetariaAsync(decimal saldoAtual, decimal percentualRendimento, int idConta);
    }
}