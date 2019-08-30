using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRallySimulation.Data.Models
{
    public class SportCar : Car
    {
        private const int maxSpeed = 140;
        private const int probOfLightMalfunction = 12;
        private const int probOfHeavyMalfunction = 2;

        public SportCar()
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