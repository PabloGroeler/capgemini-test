using capgemini_test.src.Core.Domain.Interfaces.Repositories;
using capgemini_test.src.Core.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace capgemini_test.src.Core.CrossCutting.DependencyInjection
{
    public class ConfigureDependencyRepositories
    {
        public static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
        }
    }
}