using CKLabs.Business.Interfaces;
using CKLabs.Business.Notificacoes;
using CKLabs.Business.Services;
using CKLabs.Data.Context;
using CKLabs.Data.Repository;

namespace CKLabs.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // Data
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            // Business
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
