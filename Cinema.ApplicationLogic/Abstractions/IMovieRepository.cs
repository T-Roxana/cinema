using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Abstractions
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        IEnumerable<MoviePlanning> GetAllProgramForMovie(Guid movieId);
        void AddPlanning(MoviePlanning moviePlanningToAdd);
        IEnumerable<MoviePlanning> GetProgramDayForMovie(Guid movieId, DateTime date);
    }
}
