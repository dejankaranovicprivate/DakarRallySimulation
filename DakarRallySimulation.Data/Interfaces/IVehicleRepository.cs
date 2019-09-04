using DakarRallySimulation.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallySimulation.Data.Interfaces
{
    public interface IVehicleRepository
    {
        void AddVehicleToRace(Vehicle vehicle);
        void UpdateVehicleInfo(int id, Vehicle vehicle);
        void RemoveVehicleFromTheRace(int id);
        IEnumerable<Vehicle> GetVehiclesLeaderboard();
        IEnumerable<Vehicle> GetVehiclesLeaderboardByType(string type);
        IEnumerable<Vehicle> GetVehiclesByMultipleParameters(string team, string model, DateTime manufacturingDate, VehicleStatus status, int distance);
    }
}
