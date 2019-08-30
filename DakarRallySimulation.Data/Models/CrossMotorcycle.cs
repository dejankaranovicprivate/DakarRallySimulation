using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRallySimulation.Data.Models
{
    public class CrossMotorcycle : Motorcycle
    {
        private const int maxSpeed = 85;
        private const int probOfLightMalfunction = 3;
        private const int probOfHeavyMalfunction = 2;

        public CrossMotorcycle()
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