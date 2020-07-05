using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Models
{
    public class Movie : DataEntity
    {
        public string Title { get; private set; }
        public string Image { get; private set; }

        public static Movie Create(string title, string image)
        {
            return new Movie
            {
                Id = Guid.NewGuid(),
                Title = title,
                Image = image
            };
        }

        public Movie Update(string title, string image)
        {
            this.Title = title;
            this.Image = image;
            return this;
        }
    }
}
