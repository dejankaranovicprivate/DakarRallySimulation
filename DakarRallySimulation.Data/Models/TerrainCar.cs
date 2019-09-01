using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRallySimulation.Data.Models
{
    public class TerrainCar : Car
    {
        private const int maxSpeed = 100;
        private const int probOfLightMalfunction = 3;
        private const int probOfHeavyMalfunction = 1;

        public TerrainCar()
        {
            Type = type;
            Status = VehicleStatus.Pending;
            MaxSpeed = maxSpeed;
            RepairmentLast = repairmentLast;
            ProbOfLightMalfunction = probOfLightMalfunction;
            ProbOfHeavyMalfunction = probOfHeavyMalfunction;
        }
    }
}