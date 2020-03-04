using Core.Entities.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class ComprovantePagamentoMap : IEntityTypeConfiguration<ComprovantePagamento>, IMappingWarren
    {
        public void Configure(EntityTypeBuilder<ComprovantePagamento> builder)
        {
            builder.ToTable("comprovante_pagamento").HasKey(o => o.Id);

            builder.Property(o => o.Id).HasColumnName("id").HasColumnType("INT");
            builder.Property(o => o.CodigoBarras).HasColumnName("codigo_barras").HasColumnType("VARCHAR(9)").IsRequired();
            builder.Property(o => o.Destinatario).HasColumnName("destinatario").HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(o => o.Valor).HasColumnName("valor").HasColumnType("DECIMAL").IsRequired();
            builder.Property(o => o.IdExtrato).HasColumnName("id_extrato").HasColumnType("INT").IsRequired();
        }
    }
}