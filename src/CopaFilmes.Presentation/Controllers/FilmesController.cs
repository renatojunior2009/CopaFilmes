using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.Services;
using CopaFilmes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        #region Fileds
        private readonly IFilmeService _filmeService;
        private readonly IFilmeApi _filmeApi;
        #endregion

        #region Methods Publics
        // GET api/values
        [HttpGet]
        public async Task<List<Filme>> ListarFilmes() => await _filmeApi.GetFilmes();
        #endregion

        #region Constructor
        public FilmesController(IFilmeService filmeService, IFilmeApi filmeApi)
        {
            _filmeService = filmeService;
            _filmeApi = filmeApi;
        }        
        #endregion
    }
}
