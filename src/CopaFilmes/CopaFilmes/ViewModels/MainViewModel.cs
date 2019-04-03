using CopaFilmes.Model;
using CopaFilmes.Pages.Interfaces;
using CopaFilmes.ViewModels.Base;
using CopaFilmes.ViewModels.Interfaces;

namespace CopaFilmes.ViewModels
{
    public class MainViewModel : ViewModelBaseList<IMainPage, FilmeModel>, IMainViewModel
    {

    }
}
