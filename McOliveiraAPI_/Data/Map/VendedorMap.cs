using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McOliveiraAPI_.Data.Map
{
    public class VendedorMap : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.idUser).IsRequired();
            builder.Property(x => x.Nome);
            builder.Property(x => x.ativo).IsRequired();
        }
    }
}
