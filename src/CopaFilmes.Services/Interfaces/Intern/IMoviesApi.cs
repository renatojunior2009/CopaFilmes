using CopaFilmes.Domain.Entities;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Services.Interfaces.Intern
{
    public interface IMoviesApi
    {

        [Get("/filmes")]
        Task<List<Movie>> GetMovies();
    }
}
