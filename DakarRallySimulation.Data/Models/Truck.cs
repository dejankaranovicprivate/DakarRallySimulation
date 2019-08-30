using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRallySimulation.Data.Models
{
    public class Truck : Vehicle
    {
        private const int maxSpeed = 80;
        private const int repairmentLast = 7;
        private const int probOfLightMalfunction = 6;
        private const int probOfHeavyMalfunction = 4;
        private const string type = "Truck";

        public Truck()
        {
            VehicleType = type;
            Status = VehicleStatus.Pending;
            MaxSpeed = maxSpeed;
            RepairmentLast = repairmentLast;
            ProbOfLightMalfunction = probOfLightMalfunction;
            ProbOfHeavyMalfunction = probOfHeavyMalfunction;
        }
    }
}