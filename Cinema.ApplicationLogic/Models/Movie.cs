using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Models
{
    public class Movie : DataEntity
    {
        public string Title { get; private set; }

        public static Movie Create(string title)
        {
            return new Movie
            {
                Id = Guid.NewGuid(),
                Title = title
            };
        }

        public Movie Update(string title)
        {
            this.Title = title;
            return this;
        }
    }
}
