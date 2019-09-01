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

        void UpdateVehicleInfo(Vehicle vehicle);
    }
}
