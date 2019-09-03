using DakarRallySimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRallySimulation.Data.Models
{
    public class Race
    {
        public int Id { set; get; }

        public const int Distance = 10000;

        public RaceStatus Status { set; get; }

        public int Year { set; get; }
    }
}