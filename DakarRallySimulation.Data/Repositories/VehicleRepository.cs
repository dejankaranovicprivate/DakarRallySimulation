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
        public List<Vehicle> vehicles = new List<Vehicle>()
        {
            new Truck { Id = 1, Status = VehicleStatus.Pending, TeamName = "MAN", Model = "x",
                          ManufacturingDate = DateTime.Now.Date, Type = "Truck", MaxSpeed = 80,
                            RepairmentLast = 7, ProbOfLightMalfunction = 6, ProbOfHeavyMalfunction = 4 }
        };

        public void AddVehicleToRace(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public void UpdateVehicleInfo(int id, Vehicle vehicle)
        {
            foreach(var vehicleInList in vehicles)
            {
                if(vehicleInList.Id == id)
                {
                    vehicleInList.Status = vehicle.Status;
                    vehicleInList.TeamName = vehicle.TeamName;
                    vehicleInList.Model = vehicle.Model;
                    vehicleInList.ManufacturingDate = vehicle.ManufacturingDate;
                    vehicleInList.Type = vehicle.Type;
                }
            }
        }

        public void RemoveVehicleFromTheRace(int id)
        {
            vehicles.Remove(vehicles.Single(s => s.Id == id));
        }
    }
}
