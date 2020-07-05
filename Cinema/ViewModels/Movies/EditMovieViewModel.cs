using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.ViewModels.Movies
{
    public class EditMovieViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IFormFile Image { get; set; }
    }
}
