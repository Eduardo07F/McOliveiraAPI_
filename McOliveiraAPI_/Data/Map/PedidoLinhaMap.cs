using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McOliveiraAPI_.Data.Map
{
    public class PedidoLinhaMap : IEntityTypeConfiguration<PedidoLinha>
    {
        public void Configure(EntityTypeBuilder<PedidoLinha> builder)
        {
            builder.HasKey(x => x.id);

            builder.Property(x => x.idPedido)
                   .IsRequired();

            builder.Property(x => x.idProduto)
                   .IsRequired();

            builder.Property(x => x.NomeProduto)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.Quantidade)
                   .IsRequired();

            builder.Property(x => x.ValorUnitario)
                   .IsRequired();

            builder.Property(x => x.ValorTotal)
                   .IsRequired();

            builder.Property(x => x.ativo)
                   .IsRequired();
        }
    }
}
