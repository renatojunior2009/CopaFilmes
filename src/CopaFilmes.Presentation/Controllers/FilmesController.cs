using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Domain.Entity;
using CopaFilmes.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {

        readonly IFilmeService _filmeService;
        
        // GET api/values              
        public FilmesController(IFilmeService filmeService) => _filmeService = filmeService;
              
    }
}
