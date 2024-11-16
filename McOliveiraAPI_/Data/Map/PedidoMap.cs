using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McOliveiraAPI_.Data.Map
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            // Definindo a chave primária
            builder.HasKey(x => x.id);

            // Propriedades obrigatórias e tamanho de string
            builder.Property(x => x.idVendedor).IsRequired();
            builder.Property(x => x.idCliente).IsRequired();
            builder.Property(x => x.idTipoPagamento).IsRequired();

            builder.Property(x => x.NomeCliente)
                   .IsRequired()
                   .HasMaxLength(100); // Define o tamanho máximo para NomeCliente

            builder.Property(x => x.Endereco)
                   .HasMaxLength(200); // Tamanho máximo do campo Endereço

            // Propriedades de data
            builder.Property(x => x.DataCriacao).IsRequired();
            builder.Property(x => x.DataEntrega);

            // Propriedade Observacao sem tamanho definido, permite valor maior
            builder.Property(x => x.Observacao)
                   .HasColumnType("nvarchar(max)");

            // Propriedades numéricas
            builder.Property(x => x.Desconto);
            builder.Property(x => x.Adicional);
            builder.Property(x => x.Total)
                   .IsRequired();

            // Propriedade booleana
            builder.Property(x => x.ativo).IsRequired();
        }
    }
}
