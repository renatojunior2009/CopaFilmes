using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Services.Interfaces;
using Refit;

namespace CopaFilmes.Services.Services
{
    public class MovieApi : IMovieApi
    {
        #region Fields
        private readonly string BaseUrlApi = "https://copadosfilmes.azurewebsites.net/api";
        #endregion

        #region Methods Publics 
        public async Task<List<Movie>> GetMovies()
        {
            var api = RestService.For<IMovieApi>(BaseUrlApi);
            var movies = await api.GetMovies();

            return movies;
        } 
        #endregion
    }
}