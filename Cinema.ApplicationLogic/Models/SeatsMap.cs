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

        public Seats AddSeat(Seats seat)
        {
            if (this.Seats == null) Seats = new List<Seats>();
            this.Seats.Add(seat);
            return seat;
        }
    }
}
