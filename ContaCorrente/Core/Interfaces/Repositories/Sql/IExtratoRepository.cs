using Core.Entities.Sql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories.Sql
{
    public interface IExtratoRepository : IRepository<Extrato>
    {
        Task<List<Extrato>> BuscarAsync(string agencia, string conta);
    }
}