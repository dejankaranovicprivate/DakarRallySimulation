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
    public class VehicleRepository : IVehicleRepository
    {
        public void AddVehicleToRace(Vehicle vehicle)
        {
            VehicleDataAccess.AddVehicleToRace(vehicle);
        }

        public void UpdateVehicleInfo(int id, Vehicle vehicle)
        {
            VehicleDataAccess.UpdateVehicleInfo(id, vehicle);
        }

        public IEnumerable<Vehicle> GetVehiclesLeaderboard()
        {
            return VehicleDataAccess.GetVehiclesLeaderboard();
        }

        public IEnumerable<Vehicle> GetVehiclesLeaderboardByType(string type)
        {
            return VehicleDataAccess.GetVehiclesLeaderboardByType(type);
        }

        public void RemoveVehicleFromTheRace(int id)
        {
            VehicleDataAccess.RemoveVehicleFromTheRace(id);
        }
    }
}
