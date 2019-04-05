using CopaFilmes.Domain.Entities;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Services.Interfaces.Intern
{
    public interface IResultCompetitionApi
    {
        [Post("/resultcompetition")]
        Task<List<Movie>> GetMovies([Body] List<Movie> movies);
    }
}
