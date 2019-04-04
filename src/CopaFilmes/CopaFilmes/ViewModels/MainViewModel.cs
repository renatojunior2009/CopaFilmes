using AutoMapper;
using CopaFilmes.Model;
using CopaFilmes.Pages.Interfaces;
using CopaFilmes.ServicesApp.InterfacesApi;
using CopaFilmes.Utils.Collection;
using CopaFilmes.ViewModels.Base;
using CopaFilmes.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.ViewModels
{
    public class MainViewModel : ViewModelBaseList<IMainPage, MovieModel>, IMainViewModel
    {
        #region Fields 
        private readonly IMoviesApi _moviesApi;
        #endregion

        #region Constructor
        public MainViewModel(IMoviesApi moviesApi)
        {
            _moviesApi = moviesApi;
        }
        #endregion

        #region Methods Privates
        private async Task GetMoviesApi()
        {
            try
            {
                var movies = await _moviesApi.GetMovies();
                var moviesModel = Mapper.Map<List<MovieModel>>(movies);
                Items = new ViewModelObservableCollection<MovieModel>(moviesModel, null);
                RaisedPropertyChanged(() => Items);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Methods Publics 

        public async override void AfterBinding()
        {
            await GetMoviesApi();
        } 
        #endregion
    }
}
