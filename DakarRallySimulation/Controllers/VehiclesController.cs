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
    public class VehiclesController : ApiController
    {
        private IVehicleRepository vehicles;

        public VehiclesController(IVehicleRepository _vehicles)
        {
            this.vehicles = _vehicles;
        }

        public void Post([FromBody]Vehicle vehicle)
        {
            vehicles.AddVehicleToRace(vehicle);
        }
    }
}
