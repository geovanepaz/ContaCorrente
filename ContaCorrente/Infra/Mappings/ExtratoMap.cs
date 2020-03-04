using Core.Entities.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class ExtratoMap : IEntityTypeConfiguration<Extrato>, IMappingWarren
    {
        public void Configure(EntityTypeBuilder<Extrato> builder)
        {
            builder.ToTable("extrato").HasKey(o => o.Id);

            builder.Property(o => o.Id).HasColumnName("id").HasColumnType("INT");
            builder.Property(o => o.IdConta).HasColumnName("id_conta").HasColumnType("INT").IsRequired();
            builder.Property(o => o.DataReferenica).HasColumnName("data_referencia ").HasColumnType("DATETIME2 ").IsRequired();
            builder.Property(o => o.TipoOperacao).HasColumnName("tipo_operacao").HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(o => o.SaldoAtual).HasColumnName("saldo_atual").HasColumnType("DECIMAL").IsRequired();
            builder.Property(o => o.SaldoAtual).HasColumnName("saldo_atual").HasColumnType("DECIMAL").IsRequired();
            builder.Property(o => o.Valor).HasColumnName("valor").HasColumnType("DECIMAL").IsRequired();
        }
    }
}