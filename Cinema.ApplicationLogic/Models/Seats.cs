﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Models
{
    public class Seats : DataEntity
    {
        public string Row { get; private set; }
        public string Column { get; private set; }
        public bool IsReserved { get; private set; }

        public static Seats Create(string row, string column)
        {
            return new Seats
            {
                Id = Guid.NewGuid(),
                Row = row,
                Column = column
            };
        }
    }
}
