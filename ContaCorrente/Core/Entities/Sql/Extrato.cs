using Core.Interfaces.Entities;
using System;

namespace Core.Entities.Sql
{
    public class Extrato : EntityBase<int>
    {
        public int IdConta { get; set; }
        public DateTime DataReferenica { get; set; }
        public string TipoOperacao { get; set; }
        public decimal SaldoAtual { get; set; }
        public decimal Valor { get; set; }
    }
}