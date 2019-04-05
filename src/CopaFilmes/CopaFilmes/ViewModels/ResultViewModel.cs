using CopaFilmes.Domain.Entities;
using CopaFilmes.Model;
using CopaFilmes.Pages.Interfaces;
using CopaFilmes.ViewModels.Base;
using CopaFilmes.ViewModels.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.ViewModels
{    
    public class ResultViewModel : ViewModelBaseList<IMoviePage, MovieModel>, IResultViewModel
    {
        #region Fields                          
        private List<Movie> _moviesWinner;
        private string _movieChampion;
        private string _movieViceChampion;
        #endregion

        #region Properties
        public List<Movie> MoviesWinner
        {
            get { return _moviesWinner; }
            set
            {
                _moviesWinner = value;
                RaisedPropertyChanged(() => MoviesWinner);
            }
        }

        public string MovieChampion
        {
            get { return _movieChampion; }
            set
            {
                _movieChampion = value;
                RaisedPropertyChanged(() => MovieChampion);
            }
        }

        public string MovieViceChampion
        {
            get { return _movieViceChampion; }
            set
            {
                _movieViceChampion = value;
                RaisedPropertyChanged(() => MovieViceChampion);
            }
        }

        #endregion

        #region Constructor
        public ResultViewModel()
        {
                   
        }
        #endregion

        #region Methods Privates
        private void LoadResult()
        {
            MovieChampion = MoviesWinner.ElementAt(0).Titulo;
            MovieViceChampion = MoviesWinner.ElementAt(1).Titulo;
        }
        #endregion

        #region Methods Publics 
        public  override void AfterBinding()
        {
            LoadResult();
        }

        #endregion

        #region Commands

        #endregion

        
    }
}

