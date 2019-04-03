using CopaFilmes.Domain.Entities;
using System.Collections.Generic;

namespace CopaFilmes.Domain.Interfaces.Services
{
    public interface IResultadoService
    {
        List<Filme> IniciarCompeticao(List<Filme> filmes);
    }
}
