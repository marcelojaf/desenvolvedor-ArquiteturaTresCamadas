using CKLabs.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CKLabs.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento da entidade Endereco
    /// </summary>
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        /// <summary>
        /// Método de configuração do mapeamento
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Numero)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(e => e.CEP)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(e => e.Complemento)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Enderecos");
        }
    }
}
