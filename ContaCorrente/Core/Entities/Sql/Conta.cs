using Core.Interfaces.Entities;
using System;

namespace Core.Entities.Sql
{
    public class Conta : EntityBase<int>
    {
        public string NumeroConta { get; set; }
        public string NumeroAgencia { get; set; }
    }
}