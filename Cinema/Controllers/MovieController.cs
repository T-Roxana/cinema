using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cinema.ApplicationLogic.Services;
using Cinema.ViewModels.Movies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieService movieService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public MovieController(MovieService movieService, IWebHostEnvironment webHostEnvironment)
        {
            this.movieService = movieService;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(new MoviesViewModel { Movies = movieService.GetAll() });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateMovieViewModel { });
        }

        [HttpPost]
        public IActionResult Create(CreateMovieViewModel viewModel)
        {
            string uploadImageDir = Path.Combine(webHostEnvironment.WebRootPath, "Images");
            string fileName = null;
            fileName = Guid.NewGuid().ToString() + "-" + viewModel.Image.FileName;
            string filePath = Path.Combine(uploadImageDir, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                viewModel.Image.CopyTo(fileStream);
            }
            movieService.Add(viewModel.Title, fileName);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return View(new EditMovieViewModel { Id = id, Title = movieService.GetById(id).Title });
        }

        [HttpPost]
        public IActionResult Edit(EditMovieViewModel viewModel)
        {
            string uploadImageDir = Path.Combine(webHostEnvironment.WebRootPath, "Images");
            string fileName = null;
            fileName = Guid.NewGuid().ToString() + "-" + viewModel.Image.FileName;
            string filePath = Path.Combine(uploadImageDir, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                viewModel.Image.CopyTo(fileStream);
            }
            movieService.Update(viewModel.Id, viewModel.Title, fileName);
            return RedirectToAction("Index");
        }
    }
}