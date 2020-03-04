using System.Net;
using Core.Interfaces.Services;
using Newtonsoft.Json;

namespace Core.ViewModels.ContaCorrente
{
    public class ResgateResponse 
    {
        public decimal ValorSacado { get; set; }
        public decimal Saldo { get; set; }
    }
}