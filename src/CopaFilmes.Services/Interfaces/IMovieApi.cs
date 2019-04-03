using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Domain.Entities;
using Refit;

namespace CopaFilmes.Services.Interfaces
{
    public interface IMovieApi
    {
        [Get("/filmes")]
        Task<List<Movie>> GetMovies();
    }
}
