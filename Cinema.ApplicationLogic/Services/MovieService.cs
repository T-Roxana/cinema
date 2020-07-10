using Cinema.ApplicationLogic.Abstractions;
using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Services
{
    public class MovieService
    {
        private readonly IMovieRepository movieRepository;
        private readonly IMovieTheaterRepository movieTheaterRepository;

        public MovieService(IMovieRepository movieRepository, IMovieTheaterRepository movieTheaterRepository)
        {
            this.movieRepository = movieRepository;
            this.movieTheaterRepository = movieTheaterRepository;
        }

        public Movie GetById(Guid id)
        {
            return movieRepository.GetById(id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return movieRepository.GetAll();
        }

        public Movie Add(string title, string star, DateTime releaseDate)
        {
            var movieToAdd = Movie.Create(title, star, releaseDate);
            return movieRepository.Add(movieToAdd);
        }

        public IEnumerable<MoviePlanning> GetAllProgramForMovie(Guid movieId)
        {
            return movieRepository.GetAllProgramForMovie(movieId);
        }

        public Movie Update(Guid id, string title)
        {
            var movieToUpdate = GetById(id);
            movieToUpdate.Update(title);
            return movieRepository.Update(movieToUpdate);
        }

        public IEnumerable<MoviePlanning> GetProgramDayForMovie(Guid movieId, int dayId)
        {
            var date = DateTime.Now.AddDays(dayId);
            return movieRepository.GetProgramDayForMovie(movieId, date);
        }

        public void Remove(Guid id)
        {
            movieRepository.Remove(id);
        }

        public void AddPlanning(Guid movieId, Guid movieTheaterId, DateTime startTime, DateTime endTime)
        {
            var movieDb = GetById(movieId);
            var movieTheaterDb = movieTheaterRepository.GetById(movieTheaterId);
            var moviePlanningToAdd = MoviePlanning.Create(movieDb, movieTheaterDb, startTime, endTime);
            movieRepository.AddPlanning(moviePlanningToAdd);
        }
    }
}
