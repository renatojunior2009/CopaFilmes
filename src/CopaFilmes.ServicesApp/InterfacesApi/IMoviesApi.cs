using CopaFilmes.DomainApp.Entities;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.ServicesApp.InterfacesApi
{
    public interface IMoviesApi
    {
        [Get("/movies")]
        Task<List<Movie>> GetMovies();
    }
}
