using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McOliveiraAPI_.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao);
            builder.Property(x => x.idFornecedor).IsRequired();
            builder.Property(x => x.Quantidade_Estoque).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.ativo).IsRequired();
            builder.Property(x => x.isBackorder).IsRequired();

        }
    }
}
