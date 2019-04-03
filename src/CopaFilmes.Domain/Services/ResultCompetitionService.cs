using System.Collections.Generic;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.Services;

namespace CopaFilmes.Domain.Services
{
    public class ResultCompetitionService : IResultCompetitionService
    {
        #region Fields
        private readonly IMovieService _movieService;
        #endregion

        #region Constructor
        public ResultCompetitionService(IMovieService movieService)
        {
            _movieService = movieService;
        }
        #endregion

        #region Methods Publics
        public List<Movie> StarCompetition(List<Movie> movies)
        {
            var moviesSelected = _movieService.OrderMoviesInitCompetition(movies);
            var winnersQuartasFinais = _movieService.GetResultQuartasDeFinais(moviesSelected);
            var winnersSemiFinais = _movieService.GetResultSemiFinais(winnersQuartasFinais);           
            return _movieService.GetMovieWinner(winnersSemiFinais);
        }
        #endregion

    }
}
