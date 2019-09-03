using DakarRallySimulation.Data.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallySimulation.Data.DbAdapter
{
    public static class VehicleDataAccess
    {
        internal static void AddVehicleToRace(Vehicle vehicle)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnentionString()))
            {
                vehicle.RaceId = Convert.ToInt32(cnn.ExecuteScalar("select Id from Race where Status='Pending'", new DynamicParameters()));

                cnn.Execute("insert into Vehicle (Status, TeamName, Model, ManufacturingDate, Type, " +
                    "MaxSpeed, RepairmentLast, ProbOfLightMalfunction, ProbOfHeavyMalfunction, FinishTime, RaceId) " +
                    "values (@Status, @TeamName, @Model, @ManufacturingDate, @Type, " +
                    "@MaxSpeed, @RepairmentLast, @ProbOfLightMalfunction, @ProbOfHeavyMalfunction, @FinishTime, @RaceId)", vehicle);
            }
        }

        internal static void UpdateVehicleInfo(int id, Vehicle vehicle)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnentionString()))
            {
                cnn.Execute("update Vehicle set Status = @Status, TeamName = @TeamName, Model = @Model, ManufacturingDate = @ManufacturingDate," +
                    " Type = @Type, MaxSpeed = @MaxSpeed, RepairmentLast = @RepairmentLast, ProbOfLightMalfunction = @ProbOfLightMalfunction, " +
                    "ProbOfHeavyMalfunction = @ProbOfHeavyMalfunction, FinishTime = @FinishTime, RaceId = @RaceId " +
                    "where Id = '" + id + "'", vehicle);
            }
        }

        internal static List<Vehicle> GetVehiclesLeaderboard()
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnentionString()))
            {
                var output = cnn.Query<Vehicle>("select * from Vehicle order by FinishTime", new DynamicParameters());
                return output.ToList();
            }
        }

        internal static IEnumerable<Vehicle> GetVehiclesLeaderboardByType(string type)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnentionString()))
            {
                var output = cnn.Query<Vehicle>("select * from Vehicle where Type = '" + type + "' order by FinishTime", new DynamicParameters());
                return output.ToList();
            }
        }

        internal static void RemoveVehicleFromTheRace(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnentionString()))
            {
                cnn.Execute("update Vehicle set RaceId = 'NULL' where Id = '" + id + "'");
            }
        }
    }
}
