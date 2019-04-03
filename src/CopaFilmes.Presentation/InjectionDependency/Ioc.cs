using CopaFilmes.Domain.Interfaces.Services;
using CopaFilmes.Domain.Services;
using CopaFilmes.Services.Interfaces;
using CopaFilmes.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CopaFilmes.Presentation.InjectionDependency
{    
    public class IoC
    {
        public static void RegisterServicesApplication(IServiceCollection services)
        {
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<IResultadoService, ResultadoService>();
            services.AddScoped<IFilmeApi, FilmeApi>();
        }
    }
}
