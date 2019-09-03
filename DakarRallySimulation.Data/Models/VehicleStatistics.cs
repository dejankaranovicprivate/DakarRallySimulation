using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallySimulation.Data.Models
{
    public class VehicleStatistics
    {
        public int Id { set; get; }

        public int VehicleId { set; get; }

        public int Distance { set; get; }

        public int NumberOfLightMalfunctions { set; get; }

        public bool DoesHeavyMalfunctionsHappened { set; get; }

        public int FinishTime { set; get; }
    }
}
