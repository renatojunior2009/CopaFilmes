using CopaFilmes.DomainApp.Entities;
using CopaFilmes.ServicesApp.InterfacesApi;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.ServicesApp.ServicesApi
{
    public class MoviesApi : IMoviesApi
    {

        #region Fields
        private readonly string BaseUrlApi = "http://192.168.0.102:60552/api";
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
