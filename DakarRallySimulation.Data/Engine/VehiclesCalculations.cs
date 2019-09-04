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

            int maxSpeed = 0;
            int probOfHeavyMalfunction = 0;
            int probOfLightMalfunction = 0;
            int repairmentLast = 0;

            SetVehiclePerformances(ref maxSpeed, ref probOfHeavyMalfunction, ref probOfLightMalfunction, ref repairmentLast, vehicle.Type);

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

        private static void SetVehiclePerformances(ref int maxSpeed, ref int probOfHeavyMalfunction, ref int probOfLightMalfunction, ref int repairmentLast, string vehicleType)
        {
            switch (vehicleType)
            {
                case "SportCar":
                    maxSpeed = SportCar.maxSpeed;
                    probOfHeavyMalfunction = SportCar.probOfHeavyMalfunction;
                    probOfLightMalfunction = SportCar.probOfLightMalfunction;
                    repairmentLast = Car.repairmentLast;
                    break;
                case "TerrainCar":
                    maxSpeed = TerrainCar.maxSpeed;
                    probOfHeavyMalfunction = TerrainCar.probOfHeavyMalfunction;
                    probOfLightMalfunction = TerrainCar.probOfLightMalfunction;
                    repairmentLast = Car.repairmentLast;
                    break;
                case "SportMotorcycle":
                    maxSpeed = SportMotorcycle.maxSpeed;
                    probOfHeavyMalfunction = SportMotorcycle.probOfHeavyMalfunction;
                    probOfLightMalfunction = SportMotorcycle.probOfLightMalfunction;
                    repairmentLast = Motorcycle.repairmentLast;
                    break;
                case "CrossMotorcycle":
                    maxSpeed = CrossMotorcycle.maxSpeed;
                    probOfHeavyMalfunction = CrossMotorcycle.probOfHeavyMalfunction;
                    probOfLightMalfunction = CrossMotorcycle.probOfLightMalfunction;
                    repairmentLast = Motorcycle.repairmentLast;
                    break;
                default:
                    maxSpeed = Truck.maxSpeed;
                    probOfHeavyMalfunction = Truck.probOfHeavyMalfunction;
                    probOfLightMalfunction = Truck.probOfLightMalfunction;
                    repairmentLast = Truck.repairmentLast;
                    break;
            }
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
