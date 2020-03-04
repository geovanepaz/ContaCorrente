using Core.Entities.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class ContaMap : IEntityTypeConfiguration<Conta>, IMappingWarren
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("conta").HasKey(o => o.Id);

            builder.Property(o => o.Id).HasColumnName("id").HasColumnType("INT");
            builder.Property(o => o.NumeroConta).HasColumnName("numero_conta").HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(o => o.NumeroAgencia).HasColumnName("numero_agencia").HasColumnType("VARCHAR(20)").IsRequired();
        }
    }
}