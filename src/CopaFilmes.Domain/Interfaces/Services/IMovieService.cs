using CopaFilmes.Domain.Entities;
using System.Collections.Generic;

namespace CopaFilmes.Domain.Interfaces.Services
{
    public interface IMovieService
    {        
        List<Movie> OrderMoviesInitCompetition(List<Movie> movies);
        List<Movie> GetResultQuartasDeFinais(List<Movie> moviesSelected);
        List<Movie> GetResultSemiFinais(List<Movie> winnersQuartaFinais);
        List<Movie> GetMovieWinner(List<Movie> winnersSemiFinal);
    }
}
