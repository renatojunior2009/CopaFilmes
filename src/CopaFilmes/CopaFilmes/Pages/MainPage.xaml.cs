using CopaFilmes.InjectionDependency;
using CopaFilmes.Pages.Interfaces;
using CopaFilmes.ViewModels.Interfaces;
using Xamarin.Forms;

namespace CopaFilmes.Pages
{
    public partial class MainPage : ContentPage, IMainPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = IoCApp.Container.GetInstance<IMainViewModel>();
        }
    }
}
