using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.Services.Intern;
using System.Collections.Generic;
using System.Linq;


namespace CopaFilmes.Domain.Services.Intern
{
    public class MovieService : IMovieService
    {

        #region Fields
        readonly string BaseUrlApi = "https://copadosMovies.azurewebsites.net/api";

        #endregion

        #region Methods Publics 
        public List<Movie> OrderMoviesInitCompetition(List<Movie> movies)
        {
            return movies.OrderBy(f => f.Titulo).ToList();
        }

        public List<Movie> GetResultQuartasDeFinais(List<Movie> moviesSelected)
        {
            List<Movie> winnersQuartasFinais = new List<Movie>();

            var MatchWinner1 = GetTimeWinner(moviesSelected.First(), moviesSelected.Last());
            var MatchWinner2 = GetTimeWinner(moviesSelected.ElementAt(1), moviesSelected.ElementAt(6));
            var MatchWinner3 = GetTimeWinner(moviesSelected.ElementAt(2), moviesSelected.ElementAt(5));
            var MatchWinner4 = GetTimeWinner(moviesSelected.ElementAt(3), moviesSelected.ElementAt(4));

            winnersQuartasFinais.Add(MatchWinner1);
            winnersQuartasFinais.Add(MatchWinner2);
            winnersQuartasFinais.Add(MatchWinner3);
            winnersQuartasFinais.Add(MatchWinner4);

            return winnersQuartasFinais;
        }

        public List<Movie> GetResultSemiFinais(List<Movie> winnersQuartaFinais)
        {
            List<Movie> winnersSemiFinal = new List<Movie>();

            var MatchWinner1 = GetTimeWinner(winnersQuartaFinais.ElementAt(0), winnersQuartaFinais.ElementAt(1));
            var MatchWinner2 = GetTimeWinner(winnersQuartaFinais.ElementAt(2), winnersQuartaFinais.ElementAt(3));

            winnersSemiFinal.Add(MatchWinner1);
            winnersSemiFinal.Add(MatchWinner2);

            return winnersSemiFinal;
        }

        public List<Movie> GetMovieWinner(List<Movie> winnersSemiFinal)
        {
            return winnersSemiFinal.OrderByDescending(x => x.Nota).ThenBy(x => x.Titulo).ToList();
        }

        #endregion

        #region Methods Privates 
        private Movie GetTimeWinner(Movie movieA, Movie movieB)
        {
            if (movieA.Nota > movieB.Nota)
                return movieA;
            if (movieA.Nota < movieB.Nota)
                return movieB;

            //Critério de desempate
            //Caso dois Movies tenham a mesma nota, o vencedor será definido pela ordem alfabética. 
            if (string.Compare(movieA.Titulo, movieB.Titulo) < 0)
                return movieA;

            return movieB;
        }
 
        #endregion
    }
}
