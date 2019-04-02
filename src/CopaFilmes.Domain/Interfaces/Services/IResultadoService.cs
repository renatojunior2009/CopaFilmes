using CopaFilmes.Domain.Entity;
using System.Collections.Generic;

namespace CopaFilmes.Domain.Interfaces.Services
{
    public interface IResultadoService
    {
        List<Filme> IniciarCompeticao(List<Filme> filmes);
    }
}
