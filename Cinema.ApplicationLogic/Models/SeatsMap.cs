using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Models
{
    public class SeatsMap : DataEntity
    {
        public ICollection<Seats> Seats { get; private set; }
        public static SeatsMap Create()
        {
            return new SeatsMap
            {
                Id = Guid.NewGuid(),
                Seats = new List<Seats>()
            };
        }

        public void AddSeat(Seats seat)
        {
            if (Seats == null) Seats = new List<Seats>();
            Seats.Add(seat);
        }
    }
}
