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

        public void Put(int id, [FromBody]Vehicle vehicle)
        {
            vehicles.UpdateVehicleInfo(id, vehicle);
        }

        public IEnumerable<Vehicle> Get()
        {
            return vehicles.GetVehiclesLeaderboard();
        }

        public IEnumerable<Vehicle> Get(string type)
        {
            return vehicles.GetVehiclesLeaderboardByType(type);
        }

        public void Delete(int id)
        {
            vehicles.RemoveVehicleFromTheRace(id);
        }
    }
}
