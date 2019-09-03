using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRallySimulation.Data.Models
{
    public class Vehicle
    {
        public int Id { set; get; }

        public int RaceId { set; get; }

        public VehicleStatus Status { set; get; }

        public string TeamName { set; get; }

        public string Model { set; get; }

        public DateTime ManufacturingDate { set; get; }

        public string Type { set; get; }

        public int FinishTime { set; get; }
    }
}