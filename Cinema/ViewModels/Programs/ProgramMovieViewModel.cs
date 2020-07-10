using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.ViewModels.Programs
{
    public class ProgramMovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<MoviePlanning> MoviePlannings { get; set; }
    }
}
