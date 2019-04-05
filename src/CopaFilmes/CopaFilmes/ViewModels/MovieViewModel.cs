using AutoMapper;
using CopaFilmes.Model;
using CopaFilmes.Pages.Interfaces;
using CopaFilmes.Services.Interfaces.Intern;
using CopaFilmes.Utils.Collection;
using CopaFilmes.ViewModels.Base;
using CopaFilmes.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.ViewModels
{    
    public class MovieViewModel : ViewModelBaseList<IMoviePage, MovieModel>, IMovieViewModel
    {
        #region Fields 
        private readonly IMoviesApi _moviesApi;
        #endregion

        #region Constructor
        public MovieViewModel(IMoviesApi moviesApi)
        {
            _moviesApi = moviesApi;
            GetMoviesApi();
        }
        #endregion

        #region Methods Privates
        private async Task GetMoviesApi()
        {
            try
            {
                var movies = await _moviesApi.GetMovies();
                var moviesModel = Mapper.Map<IEnumerable<MovieModel>>(movies);
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
        public  override void AfterBinding()
        {
         
        }        
        #endregion
    }
}
