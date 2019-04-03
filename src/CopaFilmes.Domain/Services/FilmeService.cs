using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Domain.Services
{
    public class FilmeService : IFilmeService
    {

        #region Fields
        readonly string BaseUrlApi = "https://copadosfilmes.azurewebsites.net/api";

        #endregion

        #region Methods Publics 
        public List<Filme> OrdenarFilmesParaIniciarCompeticao(List<Filme> filmes)
        {
            return filmes.OrderBy(f => f.Titulo).ToList();
        }

        public List<Filme> ProcessaResultadosQuartasDeFinais(List<Filme> filmesSelecionados)
        {
            List<Filme> vencedoresQuartasFinais = new List<Filme>();

            var vencedorConfronto1 = RetornarTimeVencedor(filmesSelecionados.First(), filmesSelecionados.Last());
            var vencedorConfronto2 = RetornarTimeVencedor(filmesSelecionados.ElementAt(1), filmesSelecionados.ElementAt(6));
            var vencedorConfronto3 = RetornarTimeVencedor(filmesSelecionados.ElementAt(2), filmesSelecionados.ElementAt(5));
            var vencedorConfronto4 = RetornarTimeVencedor(filmesSelecionados.ElementAt(3), filmesSelecionados.ElementAt(4));

            vencedoresQuartasFinais.Add(vencedorConfronto1);
            vencedoresQuartasFinais.Add(vencedorConfronto2);
            vencedoresQuartasFinais.Add(vencedorConfronto3);
            vencedoresQuartasFinais.Add(vencedorConfronto4);

            return vencedoresQuartasFinais;
        }

        public List<Filme> ProcessaResultadosSemiFinais(List<Filme> vencedoresQuartaFinais)
        {
            List<Filme> vencedoresSemiFinal = new List<Filme>();

            var vencedorConfronto1 = RetornarTimeVencedor(vencedoresQuartaFinais.ElementAt(0), vencedoresQuartaFinais.ElementAt(1));
            var vencedorConfronto2 = RetornarTimeVencedor(vencedoresQuartaFinais.ElementAt(2), vencedoresQuartaFinais.ElementAt(3));

            vencedoresSemiFinal.Add(vencedorConfronto1);
            vencedoresSemiFinal.Add(vencedorConfronto2);

            return vencedoresSemiFinal;
        }

        public List<Filme> DefinirFilmeVencedor(List<Filme> vencedoresSemiFinal)
        {
            return vencedoresSemiFinal.OrderByDescending(x => x.Nota).ThenBy(x => x.Titulo).ToList();
        }

        #endregion

        #region Methods Privates 
        private Filme RetornarTimeVencedor(Filme filmeA, Filme filmeB)
        {
            if (filmeA.Nota > filmeB.Nota)
                return filmeA;
            if (filmeA.Nota < filmeB.Nota)
                return filmeB;

            //Critério de desempate
            //Caso dois filmes tenham a mesma nota, o vencedor será definido pela ordem alfabética. 
            if (string.Compare(filmeA.Titulo, filmeB.Titulo) < 0)
                return filmeA;

            return filmeB;
        }

 
        #endregion
    }
}
