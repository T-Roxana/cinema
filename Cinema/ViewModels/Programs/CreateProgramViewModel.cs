using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.ViewModels.Programs
{
    public class CreateProgramViewModel
    {
        public Guid MovieId { get; set; }
        public Guid MovieTheaterId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public IEnumerable<MovieTheater> MovieTheaters { get; set; }
    }
}
