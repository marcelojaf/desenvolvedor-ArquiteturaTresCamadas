using CKLabs.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace CKLabs.Data.Context
{
    /// <summary>
    /// Classe de contexto do banco de dados
    /// </summary>
    public class MeuDbContext : DbContext
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="options"></param>
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;

        }

        /// <summary>
        /// Mapeamento da entidade Produto
        /// </summary>
        public DbSet<Produto> Produtos { get; set; }

        /// <summary>
        /// Mapemento da entidade Endereco
        /// </summary>
        public DbSet<Endereco> Enderecos { get; set; }

        /// <summary>
        /// Mapeamento da entidade Fornecedor
        /// </summary>
        public DbSet<Fornecedor> Fornecedores { get; set; }



        /// <summary>
        /// Aplica configurações extras ao DbContext
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.Entity<Produto>().Property(p => p.Valor).HasColumnType("decimal(18,2)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Salvando alterações no banco de dados
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
