using Core.ViewModels.ContaCorrente;
using System.Threading.Tasks;

namespace App.Interfaces
{
    public interface IResgateSaldoAppService
    {
        Task<ResgateResponse> ResgatarAsync(ResgateRequest resgate);
    }
}