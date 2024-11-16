using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McOliveiraAPI_.Data.Map
{
    public class TipoPagamentoMap : IEntityTypeConfiguration<TipoPagamento>
    {
        public void Configure(EntityTypeBuilder<TipoPagamento> builder)
        {
            builder.HasKey(x => x.id);

            builder.Property(x => x.NomeTipo)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.ativo)
                   .IsRequired();
        }
    }
}
