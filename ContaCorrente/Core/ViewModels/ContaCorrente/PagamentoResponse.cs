using System.Net;
using Core.Interfaces.Services;
using Newtonsoft.Json;

namespace Core.ViewModels.ContaCorrente
{
    public class PagamentoResponse 
    {
        public string CodigoDeBarras  { get; set; }
        public string NomeBeneficiario  { get; set; } 
        public decimal ValorConta  { get; set; } 
        public decimal ValorPago  { get; set; } 
    }
}