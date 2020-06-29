using Cinema.ApplicationLogic.Abstractions;
using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Services
{
    public class MovieTheaterService
    {
        private readonly IMovieTheaterRepository movieTheaterRepository;

        public MovieTheaterService(IMovieTheaterRepository movieTheaterRepository)
        {
            this.movieTheaterRepository = movieTheaterRepository;
        }

        public MovieTheater GetById(Guid id)
        {
            return movieTheaterRepository.GetById(id);
        }

        public IEnumerable<MovieTheater> GetAll()
        {
            return movieTheaterRepository.GetAll();
        }

        public MovieTheater Disable(Guid id)
        {
            var movieTheaterToDisable = GetById(id);
            movieTheaterToDisable.Disable();
            return movieTheaterRepository.Update(movieTheaterToDisable);
        }

        public MovieTheater Activate(Guid id)
        {
            var movieTheaterToDisable = GetById(id);
            movieTheaterToDisable.Activate();
            return movieTheaterRepository.Update(movieTheaterToDisable);
        }
    }
}
