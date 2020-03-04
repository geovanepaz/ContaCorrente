using Core.Entities.Sql;
using System;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IDepositarService
    {
        Task<Extrato> DepositarAsync(decimal saldoAtual, decimal valorDeposito, int idConta);
    }
}