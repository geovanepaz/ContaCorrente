using System.Net;
using Core.Interfaces.Services;
using Newtonsoft.Json;

namespace Core.ViewModels.ContaCorrente
{
    public class PagamentoRequest 
    {
        public int IdContaCedente { get; set; }
        public decimal ValorPagamento  { get; set; }
        public DadosPagamento DadosPagamento { get; set; }
    }

    public class DadosPagamento 
    {
        public string CodigoBarras  { get; set; }
        public string NomeBeneficiario  { get; set; } 
        public decimal ValorConta  { get; set; } 
    }
}