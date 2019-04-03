using System.Collections.Generic;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.Services;

namespace CopaFilmes.Domain.Services
{
    public class ResultadoService : IResultadoService
    {
        #region Fields
        private readonly IFilmeService _filmeService;
        #endregion

        #region Constructor
        public ResultadoService(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }
        #endregion

        #region Methods Publics
        public List<Filme> IniciarCompeticao(List<Filme> filmes)
        {
            var filmesEscolhidos = _filmeService.OrdenarFilmesParaIniciarCompeticao(filmes);
            var vencedoresQuartasFinais = _filmeService.ProcessaResultadosQuartasDeFinais(filmesEscolhidos);
            var vencedoresSemiFinais = _filmeService.ProcessaResultadosSemiFinais(vencedoresQuartasFinais);           
            return _filmeService.DefinirFilmeVencedor(vencedoresSemiFinais);
        }
        #endregion

    }
}
