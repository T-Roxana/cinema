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

        public MovieTheater Add(string name,
                                int numberOfRows,
                                int numberOfColumns,
                                bool isActive)
        {
            var seatsMap = SeatsMap.Create();
            for (int i = 1; i <= numberOfRows; i++)
            {
                for (int j = 1; j <= numberOfColumns; j++)
                {
                    var seat = Seats.Create(i, j);
                    seatsMap.AddSeat(seat);
                }
            }
            var movieTheater = MovieTheater.Create(seatsMap, name, numberOfRows * numberOfColumns, isActive);
            return movieTheaterRepository.Add(movieTheater);
        }

        public MovieTheater GetById(Guid id)
        {
            return movieTheaterRepository.GetById(id);
        }

        public IEnumerable<MovieTheater> GetAll()
        {
            return movieTheaterRepository.GetAll();
        }

        public void Edit(Guid id, string name, bool isActive)
        {
            var movieTheaterDb = movieTheaterRepository.GetById(id);
            movieTheaterDb.Edit(name, isActive);
            movieTheaterRepository.Update(movieTheaterDb);
        }
    }
}
