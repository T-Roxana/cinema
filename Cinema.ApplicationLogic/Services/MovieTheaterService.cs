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

        public MovieTheater ChangeStatus(Guid id, bool status)
        {
            var movieTheaterToDisable = GetById(id);
            movieTheaterToDisable.ChangeStatus(status);
            return movieTheaterRepository.Update(movieTheaterToDisable);
        }

        public MovieTheater Add(string name, int numberOfRows, int numberOfColumns)
        {
            var movieTheater = MovieTheater.Create(name, numberOfRows, numberOfColumns);
            return movieTheaterRepository.Add(movieTheater);
        }
    }
}
