using CopaFilmes.Domain.Entities;
using CopaFilmes.Services.Interfaces.Intern;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Services.Intern
{
    public class MoviesApi : IMoviesApi
    {

        #region Fields
        private readonly string BaseUrlApi = "http://192.168.254.86:45455/api";        
        #endregion

        #region Methods Publics 
        public async Task<List<Movie>> GetMovies()
        {
            var api = RestService.For<IMoviesApi>(BaseUrlApi);
            var movies = await api.GetMovies();

            return movies;
        }
        #endregion

    }
}
