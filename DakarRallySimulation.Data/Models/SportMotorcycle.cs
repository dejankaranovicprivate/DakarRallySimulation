using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRallySimulation.Data.Models
{
    public class SportMotorcycle : Motorcycle
    {
        private const int maxSpeed = 130;
        private const int probOfLightMalfunction = 18;
        private const int probOfHeavyMalfunction = 10;

        public SportMotorcycle()
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