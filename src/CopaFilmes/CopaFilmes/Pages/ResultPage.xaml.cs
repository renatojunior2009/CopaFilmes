using CopaFilmes.InjectionDependency;
using CopaFilmes.Pages.Interfaces;
using CopaFilmes.ViewModels.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CopaFilmes.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage, IResultPage
    {
        public ResultPage()
        {
            InitializeComponent();
            App.Current.CurrentPage = this;
            BindingContext = IoCApp.Container.GetInstance<IResultViewModel>();
        }
    }
}