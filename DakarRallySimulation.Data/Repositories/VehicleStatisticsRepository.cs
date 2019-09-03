using DakarRallySimulation.Data.DbAdapter;
using DakarRallySimulation.Data.Interfaces;
using DakarRallySimulation.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallySimulation.Data.Repositories
{
    public class VehicleStatisticsRepository : IVehicleStatisticsRepository
    {
        public VehicleStatistics GetVehicleStatistics(int vehicleId)
        {
            return VehicleStatisticDataAccess.GetStatisticForVehicle(vehicleId);
        }
    }
}
