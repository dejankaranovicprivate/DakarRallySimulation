using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRallySimulation.Data.Models
{
    public class SportCar : Car
    {
        internal const int maxSpeed = 140;
        internal const int probOfLightMalfunction = 12;
        internal const int probOfHeavyMalfunction = 2;
    }
}