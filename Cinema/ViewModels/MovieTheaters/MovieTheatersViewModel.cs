using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.ViewModels.MovieTheaters
{
    public class MovieTheatersViewModel
    {
        public IEnumerable<MovieTheater> MovieTheaters { get; set; }
    }
}
