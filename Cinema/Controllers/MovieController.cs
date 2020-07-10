using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.ApplicationLogic.Services;
using Cinema.ViewModels.Movies;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieService movieService;

        public MovieController(MovieService movieService)
        {
            this.movieService = movieService;
        }

        public IActionResult Index()
        {
            return View(new MoviesViewModel { Movies = movieService.GetAll()});
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddMovieViewModel { });
        }

        [HttpPost]
        public IActionResult Add(AddMovieViewModel viewModel)
        {
            movieService.Add(viewModel.Title, viewModel.Star, viewModel.ReleaseDate);
            return RedirectToAction("Index");
        }

    }
}