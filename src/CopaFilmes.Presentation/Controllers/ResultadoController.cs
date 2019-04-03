using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CopaFilmesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoController : ControllerBase
    {
        #region MyRegion
        private readonly IResultadoService _resultadoService;
        #endregion
        #region Constructor
        public ResultadoController(IResultadoService resultadoService) => _resultadoService = resultadoService;
        #endregion

        #region Methods Publics 
        // GET api/resultado              
        [HttpGet]
        public List<Filme> ResultadoCompeticao([FromBody] List<Filme> filmes) => _resultadoService.IniciarCompeticao(filmes); 
        #endregion
    }
}