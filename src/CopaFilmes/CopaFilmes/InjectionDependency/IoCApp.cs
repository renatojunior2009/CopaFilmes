using SimpleInjector;

namespace CopaFilmes.InjectionDependency
{
    public class IoCApp
    {        
        #region Properties
        public static Container Container { get; private set; }
        #endregion

        #region Constructor
        static IoCApp() => Container = new Container(); 
        #endregion
    }
}
