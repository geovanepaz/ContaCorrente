using Core.Entities.Sql;
using Core.Exceptions;
using Core.Interfaces.Repositories.Sql;
using Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Core.Services
{
    public class RendimentoService : IRendimentoService
    {
        private readonly IExtratoRepository _extratoRepositorio;

        public RendimentoService(IExtratoRepository extratoRepositorio)
        {
            _extratoRepositorio = extratoRepositorio;
        }

        public async Task<Extrato> AplicarCorrecaoMonetariaAsync(decimal saldoAtual, decimal percentualRendimento, int idConta)
        {
            decimal valorAjuste = saldoAtual * (percentualRendimento/100);

            var extratoDeposito = new Extrato
            {
                DataReferenica = DateTime.Now,
                IdConta = idConta,
                TipoOperacao = "correcaoMonetaria",
                SaldoAtual = saldoAtual + valorAjuste,
                Valor = valorAjuste,
            };

            return await _extratoRepositorio.InsertAsync(extratoDeposito);
        }
    }
}
