using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Services.Interfaces;
using Refit;

namespace CopaFilmes.Services.Services
{
    public class FilmeApi : IFilmeApi
    {
        #region Fields
        private readonly string BaseUrlApi = "https://copadosfilmes.azurewebsites.net/api";
        #endregion

        #region Methods Publics 
        public async Task<List<Filme>> GetFilmes()
        {
            var api = RestService.For<IFilmeApi>(BaseUrlApi);
            var filmes = await api.GetFilmes();

            return filmes;
        } 
        #endregion
    }
}