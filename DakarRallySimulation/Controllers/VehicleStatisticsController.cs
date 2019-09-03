using DakarRallySimulation.Data.Interfaces;
using DakarRallySimulation.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DakarRallySimulation.Controllers
{
    public class VehicleStatisticsController : ApiController
    {
        private IVehicleStatisticsRepository vehicleStatistics;

        public VehicleStatisticsController(IVehicleStatisticsRepository _vehicleStatistics)
        {
            this.vehicleStatistics = _vehicleStatistics;
        }

        public VehicleStatistics Get(int vehicleId)
        {
            return vehicleStatistics.GetVehicleStatistics(vehicleId);
        }
    }
}
