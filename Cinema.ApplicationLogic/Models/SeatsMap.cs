using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Models
{
    public class SeatsMap : DataEntity
    {
        public ICollection<Seats> Seats { get; private set; }
    }
}
