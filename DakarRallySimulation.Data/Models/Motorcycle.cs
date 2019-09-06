using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRallySimulation.Data.Models
{
    public class Motorcycle : Vehicle
    {
        internal const int repairmentLast = 3;

        public override int GetRepairmentLast()
        {
            return repairmentLast;
        }
    }
}