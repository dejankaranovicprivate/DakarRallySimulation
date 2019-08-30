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

        public int Distance { set; get; }

        public RaceStatus Status { set; get; }

        public int Year { set; get; }
    }
}