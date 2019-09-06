using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRallySimulation.Data.Models
{
    public class Car : Vehicle
    {
        internal const int repairmentLast = 5;

        public override int GetMaxSpeed()
        {
            throw new NotImplementedException();
        }

        public override int GetProbOfHeavyMalfunction()
        {
            throw new NotImplementedException();
        }

        public override int GetProbOfLightMalfunction()
        {
            throw new NotImplementedException();
        }

        public override int GetRepairmentLast()
        {
            return repairmentLast;
        }
    }
}