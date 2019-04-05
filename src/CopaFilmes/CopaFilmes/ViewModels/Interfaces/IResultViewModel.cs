using CopaFilmes.Domain.Entities;
using System.Collections.Generic;

namespace CopaFilmes.ViewModels.Interfaces
{
    public interface IResultViewModel
    {
        List<Movie> MoviesWinner { get; set; }
    }
}
