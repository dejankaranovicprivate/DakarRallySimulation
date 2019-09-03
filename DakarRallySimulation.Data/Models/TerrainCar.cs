using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRallySimulation.Data.Models
{
    public class TerrainCar : Car
    {
        internal const int maxSpeed = 100;
        internal const int probOfLightMalfunction = 3;
        internal const int probOfHeavyMalfunction = 1;
    }
}