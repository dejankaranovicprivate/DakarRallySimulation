using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRallySimulation.Data.Models
{
    public class Vehicle
    {
        public int Id { set; get; }

        public VehicleStatus Status { set; get; }

        public string TeamName { set; get; }

        public string Model { set; get; }

        public DateTime ManufacturingDate { set; get; }

        public string VehicleType { set; get; }

        public int MaxSpeed { set; get; }

        public int RepairmentLast { set; get; }

        public int ProbOfLightMalfunction { set; get; }

        public int ProbOfHeavyMalfunction { set; get; }

        public int FinishTime { set; get; }
    }
}