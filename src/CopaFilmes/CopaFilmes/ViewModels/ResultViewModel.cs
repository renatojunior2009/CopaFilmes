using CopaFilmes.Domain.Entities;
using CopaFilmes.Model;
using CopaFilmes.Pages.Interfaces;
using CopaFilmes.Services.Interfaces.Intern;
using CopaFilmes.ViewModels.Base;
using CopaFilmes.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.ViewModels
{    
    public class ResultViewModel : ViewModelBaseList<IMoviePage, MovieModel>, IResultViewModel
    {
        #region Fields                          
        private List<Movie> _moviesWinner;
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
        #endregion

        #region Constructor
        public ResultViewModel()
        {
                   
        }
        #endregion

        #region Methods Privates
      
        #endregion

        #region Methods Publics 
        public  override void AfterBinding()
        {
         
        }
        #endregion

        #region Commands
       
        #endregion
    }
}
