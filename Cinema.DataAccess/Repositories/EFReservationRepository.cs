using Cinema.ApplicationLogic.Abstractions;
using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DataAccess.Repositories
{
    public class EFReservationRepository : EFBaseRepository<Reservation>, IReservationRepository
    {
        public EFReservationRepository(CinemaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
