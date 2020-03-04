using System;
using System.Net;
using Core.Interfaces.Services;
using Newtonsoft.Json;

namespace Core.ViewModels.ContaCorrente
{
    public class ExtratoResponse 
    {
        public DateTime DataReferenica { get; set; }
        public string TipoOperacao { get; set; }
        public decimal Saldo { get; set; }
        public decimal ValorOperacao { get; set; }

    }
}