using CKLabs.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CKLabs.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento da entidade Produto
    /// </summary>
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        /// <summary>
        /// Configuração do mapeamento
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.ToTable("Produtos");
        }
    }
}
