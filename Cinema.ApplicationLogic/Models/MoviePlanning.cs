using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Models
{
    public class MoviePlanning : DataEntity
    {
        public MovieTheater MovieTheater { get; private set; }
        public Movie Movie { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
    }
}
