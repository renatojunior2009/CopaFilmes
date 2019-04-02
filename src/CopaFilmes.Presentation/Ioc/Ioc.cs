using CopaFilmes.Domain.Interfaces.Services;
using CopaFilmes.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CopaFilmes.Presentation.Ioc
{    
    public class Ioc
    {
        public static void RegisterServicesApplication(IServiceCollection services)
        {
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<IResultadoService, ResultadoService>();
        }
    }
}
