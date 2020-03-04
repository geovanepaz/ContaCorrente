using Core.ViewModels.ContaCorrente;
using System.Threading.Tasks;

namespace App.Interfaces
{
    public interface IPagamentoAppService
    {
        Task<PagamentoResponse> PagarAsync(PagamentoRequest pagamento);
    }
}