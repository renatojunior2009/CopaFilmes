using CopaFilmes.Domain.Entity;
using CopaFilmes.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CopaFilmesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoController : ControllerBase
    {
        readonly IResultadoService _resultadoService;      
        
        public ResultadoController(IResultadoService resultadoService) => _resultadoService = resultadoService;      
        
        // GET api/resultado              
        [HttpGet]
        public List<Filme> ResultadoCompeticao([FromBody] List<Filme> filmes) => _resultadoService.IniciarCompeticao(filmes);
    }
}