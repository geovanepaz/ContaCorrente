using Core.Interfaces.Entities;
using System;

namespace Core.Entities.Sql
{
    public class ComprovantePagamento : EntityBase<int>
    {
        public string CodigoBarras { get; set; }
        public string Destinatario   { get; set; }
        public Decimal Valor { get; set; }
        public int IdExtrato { get; set; }
    }
}