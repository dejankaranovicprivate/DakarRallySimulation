﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRallySimulation.Data.Models
{
    public class SportMotorcycle : Motorcycle
    {
        internal const int maxSpeed = 130;
        internal const int probOfLightMalfunction = 18;
        internal const int probOfHeavyMalfunction = 10;
    }
}