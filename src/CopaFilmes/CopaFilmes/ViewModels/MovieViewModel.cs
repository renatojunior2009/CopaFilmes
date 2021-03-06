﻿using AutoMapper;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Model;
using CopaFilmes.Pages.Interfaces;
using CopaFilmes.Services.Interfaces.Intern;
using CopaFilmes.Utils.Collection;
using CopaFilmes.ViewModels.Base;
using CopaFilmes.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CopaFilmes.ViewModels
{    
    public class MovieViewModel : ViewModelBaseList<IMoviePage, MovieModel>, IMovieViewModel
    {
        #region Fields          
        private readonly IMoviesApi _moviesApi;
        private readonly IResultCompetitionApi _resultApi;
        private List<Movie> _moviesSelected;
        private int _getCountMoviesSelected;
        private int _getTotalMovies;        
        private MovieModel _movieSelected;
        private bool _isGenerateResult;
        private string _displayMoviesSelected;
        private ICommand _gerarCommand;
        private ICommand _removeMovieCommand;
        private List<Movie> moviesWinner;
        #endregion

        #region Properties         
        public List<Movie> MoviesSelected
        {
            get { return _moviesSelected; }
            set
            {
                _moviesSelected = value;
                RaisedPropertyChanged(()=> MoviesSelected);
            }
        }

        public int GetCountMoviesSelected
        {
            get { return _getCountMoviesSelected; }
            set
            {
                _getCountMoviesSelected = value;
                RaisedPropertyChanged(() => GetCountMoviesSelected);
            }
        }

        public int GetTotalMovies
        {
            get { return _getTotalMovies; }
            set
            {
                _getTotalMovies = value;
                RaisedPropertyChanged(()=> GetTotalMovies);
            }
        }

        public string DisplayMoviesSelected
        {
            get { return ($"{GetCountMoviesSelected} de {GetTotalMovies} selecionados"); }
            set
            {
                _displayMoviesSelected = value;
                RaisedPropertyChanged(() => DisplayMoviesSelected);
            }
        }

        public MovieModel MovieSelected
        {
            get { return _movieSelected; }
            set
            {
                _movieSelected = value;

                if (_movieSelected != null)
                {
                    RaisedPropertyChanged(() => MovieSelected);
                    IsValid(value);
                    UpdateNumberMoviesSelected();
                    EnableDisableButtonGenerateResult();
                }
            }
        }
      
        public bool IsGenerateResult
        {
            get { return _isGenerateResult; }
            set
            {
                _isGenerateResult = value;
                RaisedPropertyChanged(() => IsGenerateResult);
            }
        }
        #endregion

        #region Constructor
        public MovieViewModel(IMoviesApi moviesApi, IResultCompetitionApi resultCompetitionApi)
        {
            GetTotalMovies = 0;
            GetCountMoviesSelected = 0;
            _moviesApi = moviesApi;
            _resultApi = resultCompetitionApi;
            GetMoviesApi();
            MoviesSelected = new List<Movie>();           
        }
        #endregion

        #region Methods Privates
        private async Task GetMoviesApi()
        {
            try
            {
                IsBusy = true;
                var movies = await _moviesApi.GetMovies();
                var moviesModel = Mapper.Map<IEnumerable<MovieModel>>(movies);
                Items = new ViewModelObservableCollection<MovieModel>(moviesModel, null);
                RaisedPropertyChanged(() => Items);
                UpdateDisplayMoviesSelected();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void IsValid(MovieModel novieModel)
        {
            if (MoviesSelected.Count < 8)
            {
                var movie = MoviesSelected.Where(m => m.Id == _movieSelected.Id).FirstOrDefault();
                if (movie != null)
                   DisplayAlert("Atenção", "Esse filme já foi selecionado.", "Ok");                                                      
                else
                    MoviesSelected.Add(Mapper.Map<Movie>(novieModel));
            }

            if (MoviesSelected.Count >= 8)
                DisplayAlert("Atenção", "Você já selecionou 8 filmes.", "Ok");                            
        }

        private void UpdateDisplayMoviesSelected()
        {
            GetTotalMovies = Items.Count;
            DisplayMoviesSelected = $"0 de {GetTotalMovies} selecionados";
        }

        private void EnableDisableButtonGenerateResult()
        {        
            IsGenerateResult = MoviesSelected.Count == 8 ? true : false;
        }

        private void UpdateNumberMoviesSelected()
        {
            GetCountMoviesSelected = MoviesSelected.Count;          
            RaisedPropertyChanged(() => GetCountMoviesSelected);
            RaisedPropertyChanged(() => DisplayMoviesSelected);
        }

        private async Task ProcessResult(List<Movie> moviesSelected)
        {
            if (moviesSelected == null) return;
            else            
                moviesWinner = await GetResultApi(MoviesSelected);
                        
            if(moviesWinner != null)
                await PushAsync<IResultPage, IResultViewModel>(x => x.MoviesWinner, moviesWinner);
            else
                await DisplayAlert("Ops", "Não foi possível processar resultado da competição.", "Ok");
        }


        private async Task<List<Movie>> GetResultApi(List<Movie> moviesSelected)
        {
            List<Movie> result;
            try
            {                  
                result = await  _resultApi.GetResult(moviesSelected);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return result;
        }

        #endregion

        #region Methods Publics 
        public override void AfterBinding()
        {
         
        }
        #endregion

        #region Commands
        public ICommand GerarCommand
        {
            get
            {
                return _gerarCommand ?? (_gerarCommand = new Command(async () =>
                {
                    try
                    {
                        if (MoviesSelected.Count < 8)
                        {
                            await DisplayAlert("Atenção", "Selecione 8 filmes para iniciar a competição.", "Ok");
                            return;
                        }
                        await ProcessResult(MoviesSelected);
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Ops", ex.Message, "Ok");
                    }
                }));
            }
        }

        public ICommand RemoveMovieCommand
        {
            get
            {
                return _removeMovieCommand ?? (_removeMovieCommand = new Command(async () =>
                {
                    try
                    {
                        var movie = MoviesSelected.Where(m => m.Id == _movieSelected.Id).FirstOrDefault();
                        if (movie != null)                       
                            await DisplayAlert("Atenção", $"Excluir o filme {_movieSelected.Titulo} da lista?", "Sim","Não").ContinueWith((arg) => { if (arg.Result)
                            {
                                MoviesSelected.Remove(movie);
                                UpdateNumberMoviesSelected();
                            }});                                            
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Ops", ex.Message, "Ok");
                    }
                }));
            }
        }

        #endregion
    }
}
