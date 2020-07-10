using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Models
{
    public class Reservation : DataEntity
    {
        public MoviePlanning MoviePlanning { get; private set; }
        public Customer Customer { get; private set; }
        public DateTime Date { get; private set; }

        public static Reservation Create(Customer customer, MoviePlanning moviePlanning)
        {
            return new Reservation
            {
                Id = Guid.NewGuid(),
                Customer = customer,
                MoviePlanning = moviePlanning,
                Date = DateTime.UtcNow
            };
        }
    }
}
