using CopaFilmes.Domain.Base;

namespace CopaFilmes.Domain.Entities
{
    public class Movie : EntityBase
    {
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public double Nota { get; set; }
    }
}
