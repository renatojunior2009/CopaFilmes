using CopaFilmes.InjectionDependency;
using CopaFilmes.Pages.Interfaces;
using CopaFilmes.ViewModels.Interfaces;
using Xamarin.Forms;

namespace CopaFilmes.Pages
{
    public partial class MoviePage : ContentPage, IMoviePage
    {
        public MoviePage()
        {
            InitializeComponent();
            App.Current.CurrentPage = this;
            BindingContext = IoCApp.Container.GetInstance<IMovieViewModel>();

            Movies.ItemSelected += async (sender, e) =>
            {
                //make sure the selected item isn't null for the combined reason of null object and my null reset
                if (Movies.SelectedItem != null)
                {
                    Movies.SelectedItem = null;
                }
            };
        }
    }
}
