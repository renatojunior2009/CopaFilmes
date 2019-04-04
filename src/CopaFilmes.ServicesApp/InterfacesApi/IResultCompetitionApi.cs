using CopaFilmes.DomainApp.Entities;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.ServicesApp.InterfacesApi
{
    public interface IResultCompetitionApi
    {
        [Post("/resultcompetition")]
        Task<List<Movie>> GetMovies([Body] List<Movie> movies);
    }
}
