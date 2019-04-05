﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Services.Interfaces.Intern;
using Refit;

namespace CopaFilmes.Services.Intern
{
    public class ResultCompetitionApi : IResultCompetitionApi
    {
        #region Fields
        private readonly string BaseUrlApi = "http://192.168.254.86:60552/api";
        #endregion

        #region Methods Publics 
        public async Task<List<Movie>> GetResult([Body] List<Movie> movies)
        {
            var api = RestService.For<IResultCompetitionApi>(BaseUrlApi);
            //var moviesResult = await api.GetResult();
            //return moviesResult;

            return null;
        }
        #endregion
    }
}
