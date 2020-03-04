using Core.Entities.Sql;
using Core.Exceptions;
using Core.Interfaces.Repositories.Sql;
using Core.Interfaces.Services;
using System;

namespace Core.Services
{
    public class ResgateSaldoService : IResgateSaldoService
    {
        private readonly IExtratoRepository _extratoRepositorio;

        public ResgateSaldoService(IExtratoRepository extratoRepositorio)
        {
            _extratoRepositorio = extratoRepositorio;
        }

        public Extrato Resgatar(Extrato ultimaMovimentacao)
        {
            if (ultimaMovimentacao.SaldoAtual == 0)
            {
                throw new BadRequestException("saldo insuficiente");
            }

            var extrato = new Extrato
            {
                DataReferenica = DateTime.Now,
                IdConta = ultimaMovimentacao.IdConta,
                TipoOperacao = "resgate",
                SaldoAtual = 0,
                Valor = ultimaMovimentacao.SaldoAtual,
            };

            return _extratoRepositorio.Insert(extrato);
        }

    }
}
