using capgemini_test.src.Core.Domain.Interfaces.Services;
using capgemini_test.src.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace capgemini_test.src.Core.CrossCutting.DependencyInjection
{
    public class ConfigureDependencyServices
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProdutoService, ProdutoService>();            
        }
    }
}