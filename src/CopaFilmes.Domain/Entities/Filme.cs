using CopaFilmes.Domain.Entities.Base;

namespace CopaFilmes.Domain.Entities
{
    public class Filme : EntityBase
    {       
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public double Nota { get; set; }
    }
}

