using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Models
{
    public class MovieTheater : DataEntity
    {
        public SeatsMap SeatsMaps { get; private set; }
        public int NumberOfSeats { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }

        public static MovieTheater Create(string name, int numberOfRows, int numberOfColumns)
        {
            return new MovieTheater
            {
                Id = Guid.NewGuid(),
                Name = name,
                NumberOfSeats = numberOfColumns * numberOfRows,
                IsActive = true,
                SeatsMaps = CreateSeatsMap(numberOfRows, numberOfColumns)
            };
        }

        private static SeatsMap CreateSeatsMap(int numberOfRows, int numberOfColumns)
        {
            var seatsMap = SeatsMap.Create();
            char row = 'A';
            for (var i = 1; i <= numberOfRows; i++)
            {
                for (var j = 1; j <= numberOfColumns; j++)
                {
                    var column = j.ToString();
                    var seat = Seats.Create(row.ToString(), column);
                    seatsMap.AddSeat(seat);
                }
                row++;
            }
            return seatsMap;
        }

        public bool ChangeStatus(bool status)
        {
            this.IsActive = status;
            return this.IsActive;
        }
    }
}
