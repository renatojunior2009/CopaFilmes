using CopaFilmes.Domain.Entities;
using System.Collections.Generic;

namespace CopaFilmes.Domain.Interfaces.Services.Intern
{
    public interface IResultCompetitionService
    {
        List<Movie> StarCompetition(List<Movie> Movies);
    }
}
