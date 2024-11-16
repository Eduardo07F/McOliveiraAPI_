using Microsoft.EntityFrameworkCore;
using Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McOliveiraAPI_.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cel).IsRequired().HasMaxLength(13);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(13);
            builder.Property(x => x.Cpf_Cnpj).IsRequired().HasMaxLength(18);
            builder.Property(x => x.IS_CNPJ).IsRequired();
            builder.Property(x => x.Ativo).IsRequired();
        }
    }
}
