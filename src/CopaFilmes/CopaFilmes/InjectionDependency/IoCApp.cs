using SimpleInjector;

namespace CopaFilmes.InjectionDependency
{
    public class IoCApp
    {
        #region Fields
        private static Container _container; 
        #endregion

        #region Properties
        public static Container Container => _container; 
        #endregion

        #region Constructor
        static IoCApp() => _container = new Container(); 
        #endregion
    }
}
