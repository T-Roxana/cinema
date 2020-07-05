using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Models
{
    public class MovieTheater : DataEntity
    {
        public SeatsMap SeatsMaps { get; private set; }
        public int NumberOfSeats { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        
        public static MovieTheater Create(SeatsMap seatsMap, string name, int numberOfSeats, bool isActive) 
        {
            return new MovieTheater
            {
                Id = Guid.NewGuid(),
                SeatsMaps = seatsMap,
                Name = name,
                NumberOfSeats = numberOfSeats,
                IsActive = isActive
            };
        }

        internal void Edit(string name, bool isActive)
        {
            this.Name = name;
            this.IsActive = isActive;
        }
    }
}
