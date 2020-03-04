using Core.Entities.Sql;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IPagamentoService
    {
        Task<Extrato> PagarAsync(Extrato UltimaMovimentacao, decimal valorPagamento, string codigoBarras);
        Task<ComprovantePagamento> SalvarComprovanteAsync(ComprovantePagamento comprovante);
    }
}