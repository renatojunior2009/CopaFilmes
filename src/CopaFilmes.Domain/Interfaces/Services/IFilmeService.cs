using CopaFilmes.Domain.Entity;
using System.Collections.Generic;

namespace CopaFilmes.Domain.Interfaces.Services
{
    public interface IFilmeService
    {        
        List<Filme> OrdenarFilmesParaIniciarCompeticao(List<Filme> filmes);
        List<Filme> ProcessaResultadosQuartasDeFinais(List<Filme> filmesSelecionados);
        List<Filme> ProcessaResultadosSemiFinais(List<Filme> vencedoresQuartaFinais);
        List<Filme> DefinirFilmeVencedor(List<Filme> vencedoresSemiFinal);
    }
}
