using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Models
{
    public class Seats : DataEntity
    {
        public int Number{ get; private set; }
        public int Row { get; private set; }
        public bool IsReserved { get; private set; }

        public static Seats Create(int number, int row)
        {
            return new Seats
            {
                Id = Guid.NewGuid(),
                Number = number,
                Row = row,
                IsReserved = false
            };
        }
    }
}
