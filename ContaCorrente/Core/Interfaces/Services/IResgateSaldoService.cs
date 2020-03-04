using Core.Entities.Sql;
using System;

namespace Core.Interfaces.Services
{
    public interface IResgateSaldoService
    {
        Extrato Resgatar(Extrato ultimaMovimentacao);
    }
}