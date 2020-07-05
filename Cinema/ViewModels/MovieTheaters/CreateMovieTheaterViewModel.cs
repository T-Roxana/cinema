using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.ViewModels.MovieTheaters
{
    public class CreateMovieTheaterViewModel
    {
        public string Name { get; set; }
        public int NumberSeats { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }
        public string Status{ get; set; }
    }
}
