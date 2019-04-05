using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.Services.Intern;
using CopaFilmes.Services.Interfaces.Extern;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmesApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        #region Fileds
        private readonly IMovieService _movieService;
        private readonly IMovieApi _movieApi;
        #endregion

        #region Methods Publics
        // GET api/values
        [HttpGet]
        public async Task<List<Movie>> GetMovies() => await _movieApi.GetMovies();
        #endregion

        #region Constructor
        public MoviesController(IMovieService movieService, IMovieApi movieApi)
        {
            _movieService = movieService;
            _movieApi = movieApi;
        }        
        #endregion
    }
}
