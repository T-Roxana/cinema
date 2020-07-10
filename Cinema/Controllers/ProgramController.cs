using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.ApplicationLogic.Services;
using Cinema.ViewModels.Programs;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class ProgramController : Controller
    {
        private readonly MovieService movieService;
        private readonly MovieTheaterService movieTheaterService;

        public ProgramController(MovieService movieService, MovieTheaterService movieTheaterService)
        {
            this.movieService = movieService;
            this.movieTheaterService = movieTheaterService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SeeProgramForMovie(Guid movieId)
        {
            var viewModel = new ProgramMovieViewModel
            {
                Movie = movieService.GetById(movieId)
            };
            return View(viewModel);
        }


        public IActionResult SeeProgramDayForMovie(Guid movieId, int dayId)
        {
            var viewModel = new ProgramMovieViewModel
            {
                Movie = movieService.GetById(movieId),
                MoviePlannings = movieService.GetProgramDayForMovie(movieId, dayId)
            };
            return View("SeeProgramForMovie", viewModel);
        }

        [HttpGet]
        public IActionResult Create(Guid movieId)
        {
            var viewModel = new CreateProgramViewModel
            {
                MovieId = movieId,
                MovieTheaters = movieTheaterService.GetAll()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateProgramViewModel viewModel)
        {
                movieService.AddPlanning(viewModel.MovieId, viewModel.MovieTheaterId, viewModel.StartTime, viewModel.EndTime);
                return RedirectToAction("SeeProgramForMovie", new { movieId = viewModel.MovieId });
        }
    }
}