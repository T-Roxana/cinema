using Cinema.ApplicationLogic.Abstractions;
using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DataAccess.Repositories
{
    public class EFMovieRepository : EFBaseRepository<Movie>, IMovieRepository
    {
        public EFMovieRepository(CinemaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
