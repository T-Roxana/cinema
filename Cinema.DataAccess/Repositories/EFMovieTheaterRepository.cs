using Cinema.ApplicationLogic.Abstractions;
using Cinema.ApplicationLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.DataAccess.Repositories
{
    public class EFMovieTheaterRepository : EFBaseRepository<MovieTheater>, IMovieTheaterRepository
    {
        public EFMovieTheaterRepository(CinemaDbContext dbContext) : base(dbContext)
        {
        }

        public override MovieTheater GetById(Guid id)
        {
            return dbContext.MovieTheaters.Include(movieTheater => movieTheater.SeatsMaps)
                                          .ThenInclude(movieTheater => movieTheater.Seats)
                                          .Where(movieTheater => movieTheater.Id == id)
                                          .SingleOrDefault();
        }
    }
}
