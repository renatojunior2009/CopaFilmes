using CopaFilmes.Pages;
using CopaFilmes.Pages.Interfaces;
using CopaFilmes.ViewModels;
using CopaFilmes.ViewModels.Interfaces;
using CopaFilmes.InjectionDependency;

namespace CopaFilmes
{
    public static class ModuleInitializer
    {
        public static void Initialize()
        {
            #region Registers Pages             
            IoCApp.Container.Register(typeof(IMainPage), typeof(MainPage));
            #endregion

            #region Registers View Models 
            IoCApp.Container.Register(typeof(IMainViewModel), typeof(MainViewModel));
            #endregion
        }
    }
}
