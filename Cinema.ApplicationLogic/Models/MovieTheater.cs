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

        public bool Disable()
        {
            this.IsActive = false;
            return this.IsActive;
        }

        public bool Activate()
        {
            this.IsActive = true;
            return this.IsActive;
        }
    }
}
