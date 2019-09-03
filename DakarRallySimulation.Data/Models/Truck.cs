﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRallySimulation.Data.Models
{
    public class Truck : Vehicle
    {
        internal const int maxSpeed = 80;
        internal const int repairmentLast = 7;
        internal const int probOfLightMalfunction = 6;
        internal const int probOfHeavyMalfunction = 4;
        internal const string type = "Truck";
    }
}