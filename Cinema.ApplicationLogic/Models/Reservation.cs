using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Models
{
    public class Reservation : DataEntity
    {
        public MoviePlanning MoviePlanning { get; private set; }
        public EndUser EndUser { get; private set; }
        public DateTime Date { get; private set; }

        public static Reservation Create(EndUser endUser, MoviePlanning moviePlanning)
        {
            return new Reservation
            {
                Id = Guid.NewGuid(),
                EndUser = endUser,
                MoviePlanning = moviePlanning,
                Date = DateTime.UtcNow
            };
        }
    }
}
