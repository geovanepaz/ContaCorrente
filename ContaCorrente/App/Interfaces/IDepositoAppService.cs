using Core.ViewModels.ContaCorrente;
using System.Threading.Tasks;

namespace App.Interfaces
{
    public interface IDepositoAppService
    {
        Task<object> DepositarAsync(DepositoRequest deposito);
    }
}