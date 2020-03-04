using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.ViewModels.ContaCorrente
{
    public class RendimentoRequest 
    {
        public int IdConta { get; set; }
        public decimal PercentualRendimento { get; set; }


    }
}