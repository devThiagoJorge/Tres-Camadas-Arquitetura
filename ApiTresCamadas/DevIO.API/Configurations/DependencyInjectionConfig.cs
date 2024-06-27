using DevIo.Domain.Interfaces;
using DevIo.Domain.Notificacoes;
using DevIo.Domain.Services;
using DevIO.Data.Context;
using DevIO.Data.Repository;

namespace DevIO.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //Data
            services.AddScoped<AppDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            //Domain
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
