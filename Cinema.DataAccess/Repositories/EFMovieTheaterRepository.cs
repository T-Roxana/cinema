using Cinema.ApplicationLogic.Abstractions;
using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DataAccess.Repositories
{
    public class EFMovieTheaterRepository : EFBaseRepository<MovieTheater>, IMovieTheaterRepository
    {
        public EFMovieTheaterRepository(CinemaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
