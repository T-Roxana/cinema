using Cinema.ApplicationLogic.Abstractions;
using Cinema.ApplicationLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.DataAccess.Repositories
{
    public class EFMovieRepository : EFBaseRepository<Movie>, IMovieRepository
    {
        public EFMovieRepository(CinemaDbContext dbContext) : base(dbContext)
        {
        }

        public void AddPlanning(MoviePlanning moviePlanningToAdd)
        {
            dbContext.MoviePlannings.Add(moviePlanningToAdd);
            dbContext.SaveChanges();
        }

        public IEnumerable<MoviePlanning> GetAllProgramForMovie(Guid movieId)
        {
            return dbContext.MoviePlannings
                .Include(mp => mp.Movie)
                .Include(mp => mp.MovieTheater)
                .Where(mp => mp.Movie.Id == movieId);
        }

        public IEnumerable<MoviePlanning> GetProgramDayForMovie(Guid movieId, DateTime date)
        {
            return dbContext.MoviePlannings.Include(mp => mp.Movie)
                                .Where(mp => (mp.Movie.Id == movieId && mp.Start.Day == date.Day && mp.Start.Month == date.Month));
        }
    }
}
