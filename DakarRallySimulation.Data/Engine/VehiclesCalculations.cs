using DakarRallySimulation.Data.DbAdapter;
using DakarRallySimulation.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallySimulation.Data.Engine
{
    public class VehiclesCalculations
    {
        internal static void VehiclesInRaceSimulation(int id)
        {
            var vehicles = VehicleDataAccess.GetVehiclesByRaceId(id);

            foreach(var vehicle in vehicles)
            {
                var vehicleStatistics = GetStatisticForVehicle(vehicle);
                VehicleStatisticDataAccess.AddStatisticForVehicle(vehicleStatistics);
            }
        }

        private static VehicleStatistics GetStatisticForVehicle(Vehicle vehicle)
        {
            var vehicleStatistics = new VehicleStatistics();

            var timeInPerfectCondition = Convert.ToInt32(Race.Distance / SportCar.maxSpeed);

            for(int i = 0; i < timeInPerfectCondition; i++)
            {
                if (DoesMalfunctionHappened(SportCar.probOfHeavyMalfunction))
                {
                    vehicleStatistics.DoesHeavyMalfunctionsHappened = true;
                    break;
                }
                if (DoesMalfunctionHappened(SportCar.probOfLightMalfunction))
                {
                    vehicleStatistics.FinishTime += Car.repairmentLast;
                    vehicleStatistics.NumberOfLightMalfunctions++;
                }
                vehicleStatistics.FinishTime++;
                vehicleStatistics.Distance += SportCar.maxSpeed;
            }

            return vehicleStatistics;
        }

        private static bool DoesMalfunctionHappened(int possibility)
        {
            Random random = new Random();
            var randomNumber = random.Next(1, 100);
            if (possibility >= randomNumber)
                return true;
            else
                return false;
        }
    }
}
