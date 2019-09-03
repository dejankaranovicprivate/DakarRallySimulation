using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRallySimulation.Data.Models
{
    public class CrossMotorcycle : Motorcycle
    {
        internal const int maxSpeed = 85;
        internal const int probOfLightMalfunction = 3;
        internal const int probOfHeavyMalfunction = 2;
    }
}