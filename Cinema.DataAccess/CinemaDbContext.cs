using Cinema.ApplicationLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cinema.DataAccess
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {
        }

        public DbSet<EndUser> EndUsers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MoviePlanning> MoviePlannings { get; set; }
        public DbSet<MovieTheater> MovieTheaters { get; set; }
        public DbSet<Reservation> Reservations{ get; set; }
        public DbSet<Seats> Seats{ get; set; }
        public DbSet<SeatsMap> SeatsMaps { get; set; }
    }
}
