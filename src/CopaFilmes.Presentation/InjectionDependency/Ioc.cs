using CopaFilmes.Domain.Interfaces.Services.Intern;
using CopaFilmes.Domain.Services.Intern;
using CopaFilmes.Services.Extern;
using CopaFilmes.Services.Interfaces.Extern;
using Microsoft.Extensions.DependencyInjection;

namespace CopaFilmes.Presentation.InjectionDependency
{    
    public class IoC
    {
        public static void RegisterServicesApplication(IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IResultCompetitionService, ResultCompetitionService>();
            services.AddScoped<IMovieApi, MovieApi>();
        }
    }
}
