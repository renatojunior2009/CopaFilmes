using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.Services.Intern;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CopaFilmesApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ResultCompetitionController : ControllerBase
    {
        #region MyRegion
        private readonly IResultCompetitionService _resultCompetitionService;
        #endregion
        #region Constructor
        public ResultCompetitionController(IResultCompetitionService resultCompetitionService) => _resultCompetitionService = resultCompetitionService;
        #endregion

        #region Methods Publics 
        // GET api/resultado              
        [HttpPost]
        public List<Movie> ResultCompetition([FromBody] List<Movie> movies) => _resultCompetitionService.StarCompetition(movies); 
        #endregion
    }
}