using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.ApplicationLogic.Services;
using Cinema.ViewModels.MovieTheaters;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class MovieTheaterController : Controller
    {
        private readonly MovieTheaterService movieTheaterService;

        public MovieTheaterController(MovieTheaterService movieTheaterService)
        {
            this.movieTheaterService = movieTheaterService;
        }

        public IActionResult Index()
        {
            return View(new MovieTheatersViewModel { MovieTheaters = movieTheaterService.GetAll() });
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddMovieTheaterViewModel { });
        }

        [HttpPost]
        public IActionResult Add(AddMovieTheaterViewModel viewModel)
        {
            movieTheaterService.Add(viewModel.Name, viewModel.NumberOfRows, viewModel.NumberOfColumns);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            var movieTheater = movieTheaterService.GetById(id);
            return View(new DetailsMovieTheaterViewModel { MovieTheater = movieTheater});
        }

        public IActionResult ChangeStatusActive(Guid id)
        {
            movieTheaterService.ChangeStatus(id, true);
            return RedirectToAction("Details", new { id = id });
        }

        public IActionResult ChangeStatusInactive(Guid id)
        {
            movieTheaterService.ChangeStatus(id, false);
            return RedirectToAction("Details", new { id = id });
        }
    }
}