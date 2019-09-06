using DakarRallySimulation.Data.DbAdapter;
using DakarRallySimulation.Data.Models;
using System;

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

            int maxSpeed = vehicle.GetMaxSpeed();
            int probOfHeavyMalfunction = vehicle.GetProbOfHeavyMalfunction();
            int probOfLightMalfunction = vehicle.GetProbOfLightMalfunction();
            int repairmentLast = vehicle.GetRepairmentLast();

            var timeInPerfectCondition = Convert.ToInt32(Race.Distance / maxSpeed);

            for(int i = 0; i < timeInPerfectCondition; i++)
            {
                if (DoesMalfunctionHappened(probOfHeavyMalfunction))
                {
                    vehicleStatistics.DoesHeavyMalfunctionsHappened = true;
                    break;
                }
                if (DoesMalfunctionHappened(probOfLightMalfunction))
                {
                    vehicleStatistics.FinishTime += repairmentLast;
                    vehicleStatistics.NumberOfLightMalfunctions++;
                }
                vehicleStatistics.FinishTime++;
                vehicleStatistics.Distance += maxSpeed;
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
