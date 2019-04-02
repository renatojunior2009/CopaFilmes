using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Domain.Entity;
using Refit;

namespace CopaFilmes.Services.Interfaces
{
    public interface IFilmeApi
    {
        [Get("/filmes")]
        Task<List<Filme>> GetFilmes();
    }
}
