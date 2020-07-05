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

        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public Movie GetById(Guid id)
        {
            return movieRepository.GetById(id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return movieRepository.GetAll();
        }

        public Movie Add(string title, string image)
        {
            var movieToAdd = Movie.Create(title, image);
            return movieRepository.Add(movieToAdd);
        }

        public Movie Update(Guid id, string title, string image)
        {
            var movieToUpdate = GetById(id);
            movieToUpdate.Update(title, image);
            return movieRepository.Update(movieToUpdate);
        }

        public void Remove(Guid id)
        {
            movieRepository.Remove(id);
        }
    }
}
