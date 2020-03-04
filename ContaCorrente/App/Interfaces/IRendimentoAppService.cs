using Core.Entities.Sql;
using Core.ViewModels.ContaCorrente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Interfaces
{
    public interface IRendimentoAppService
    {
        Task<ExtratoResponse> AplicarCorrecaoMonetariaAsync(RendimentoRequest rendimento);
    }
}