using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Models
{
    public class Movie : DataEntity
    {
        public string Title { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string Star { get; private set; }

        public static Movie Create(string title, string star, DateTime releaseDate)
        {
            return new Movie
            {
                Id = Guid.NewGuid(),
                Title = title,
                Star = star,
                ReleaseDate = releaseDate
            };
        }

        public Movie Update(string title)
        {
            this.Title = title;
            return this;
        }
    }
}
