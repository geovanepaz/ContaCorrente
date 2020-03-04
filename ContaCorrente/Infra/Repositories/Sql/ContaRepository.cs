using Core.Entities.Sql;
using Core.Interfaces.Repositories.Sql;
using Infra.Contexts;

namespace Infra.Repositories.Sql
{
    public class ContaoRepository : Repository<Conta>, IContaRepository
    {
        public ContaoRepository(IWarrenContext contex) : base(contex)
        {
        }
    }
}