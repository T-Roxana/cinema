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
            return View(new MovieTheaterViewModel { MovieTheaters = movieTheaterService.GetAll() });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateMovieTheaterViewModel { });
        }

        [HttpPost]
        public IActionResult Create(CreateMovieTheaterViewModel viewModel)
        {
            bool isActive = true;
            if (viewModel.Status == "Inactive" || viewModel.Status == "inactive") isActive = false;
            movieTheaterService.Add(viewModel.Name, viewModel.NumberOfRows, viewModel.NumberOfColumns, isActive);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var movieTheaterDb = movieTheaterService.GetById(id);
            string status = "Active";
            if (!movieTheaterDb.IsActive) status = "Inactive";
            return View(new EditMovieTheaterViewModel 
            { 
                Id = id,
                Name = movieTheaterDb.Name,
                Status = status
            });
        }

        [HttpPost]
        public IActionResult Edit(EditMovieTheaterViewModel viewModel)
        {
            var isActive = true;
            if (viewModel.Status == "Inactive" || viewModel.Status == "inactive") isActive = false;
            movieTheaterService.Edit(viewModel.Id, viewModel.Name, isActive);
            return RedirectToAction("Index");
        }

        public IActionResult SeeMap(Guid id)
        {
            return View(movieTheaterService.GetById(id));
        }
    }
}