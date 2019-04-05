using CopaFilmes.Pages;
using CopaFilmes.Pages.Interfaces;
using CopaFilmes.ViewModels;
using CopaFilmes.ViewModels.Interfaces;
using CopaFilmes.InjectionDependency;
using CopaFilmes.Services.Interfaces.Intern;
using CopaFilmes.Services.Intern;

namespace CopaFilmes
{
    public static class ModuleInitializer
    {
        public static void Initialize()
        {
            #region Registers Pages             
            IoCApp.Container.Register(typeof(IMoviePage), typeof(MoviePage));
            IoCApp.Container.Register(typeof(IResultPage), typeof(ResultPage));
            #endregion

            #region Registers View Models 
            IoCApp.Container.Register(typeof(IMovieViewModel), typeof(MovieViewModel));
            IoCApp.Container.Register(typeof(IResultViewModel), typeof(ResultViewModel));
            #endregion

            #region Services Api
            IoCApp.Container.Register(typeof(IMoviesApi), typeof(MoviesApi));
            IoCApp.Container.Register(typeof(IResultCompetitionApi), typeof(ResultCompetitionApi));
            #endregion
        }
    }
}
