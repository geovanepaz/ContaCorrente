using Core.Entities.Sql;
using Core.Interfaces.Repositories.Sql;
using Infra.Contexts;

namespace Infra.Repositories.Sql
{
    public class ComprovantePagamentoRepository : Repository<ComprovantePagamento>, IComprovantePagamentoRepository
    {
        public ComprovantePagamentoRepository(IWarrenContext contex) : base(contex)
        {
        }
    }
}