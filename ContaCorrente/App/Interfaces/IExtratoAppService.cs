using Core.ViewModels.ContaCorrente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Interfaces
{
    public interface IExtratoAppService
    {
        Task<List<ExtratoResponse>> SolicitarAsync(int idConta);
    }
}