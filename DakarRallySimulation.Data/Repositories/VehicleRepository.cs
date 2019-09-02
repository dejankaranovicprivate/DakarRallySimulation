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
            SqliteDataAccess.AddVehicleToRace(vehicle);
        }

        public void UpdateVehicleInfo(int id, Vehicle vehicle)
        {
            SqliteDataAccess.UpdateVehicleInfo(id, vehicle);
        }

        public IEnumerable<Vehicle> GetVehiclesLeaderboard()
        {
            return SqliteDataAccess.GetVehiclesLeaderboard();
        }

        public IEnumerable<Vehicle> GetVehiclesLeaderboardByType(string type)
        {
            return SqliteDataAccess.GetVehiclesLeaderboardByType(type);
        }

        public void RemoveVehicleFromTheRace(int id)
        {
            SqliteDataAccess.RemoveVehicleFromTheRace(id);
        }
    }
}
