using Core.Entities.Sql;
using Core.Exceptions;
using Core.Interfaces.Repositories.Sql;
using Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Core.Services
{
    public class DepositarService : IDepositarService
    {
        private readonly IExtratoRepository _extratoRepositorio;

        public DepositarService(IExtratoRepository extratoRepositorio)
        {
            _extratoRepositorio = extratoRepositorio;
        }

        public async Task<Extrato> DepositarAsync(decimal saldoAtual, decimal valorDeposito, int idConta)
        {
            var extratoDeposito = new Extrato
            {
                DataReferenica = DateTime.Now,
                IdConta = idConta,
                TipoOperacao = "deposito",
                SaldoAtual = saldoAtual + valorDeposito,
                Valor = valorDeposito,
            };

            return await _extratoRepositorio.InsertAsync(extratoDeposito);
        }
    }
}
