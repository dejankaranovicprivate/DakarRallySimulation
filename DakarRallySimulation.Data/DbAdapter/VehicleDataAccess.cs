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
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                vehicle.RaceId = Convert.ToInt32(cnn.ExecuteScalar("select Id from Race where Status='Pending'", new DynamicParameters()));

                cnn.Execute("insert into Vehicle (Status, TeamName, Model, ManufacturingDate, Type, FinishTime, RaceId) " +
                    "values (@Status, @TeamName, @Model, @ManufacturingDate, @Type, @FinishTime, @RaceId)", vehicle);
            }
        }

        internal static void UpdateVehicleInfo(int id, Vehicle vehicle)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                cnn.Execute("update Vehicle set Status = @Status, TeamName = @TeamName, Model = @Model, ManufacturingDate = @ManufacturingDate," +
                    " Type = @Type, FinishTime = @FinishTime, RaceId = @RaceId where Id = '" + id + "'", vehicle);
            }
        }

        internal static List<Vehicle> GetVehiclesLeaderboard()
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                var output = cnn.Query<Vehicle>("select * from Vehicle order by FinishTime", new DynamicParameters());
                return output.ToList();
            }
        }

        internal static IEnumerable<Vehicle> GetVehiclesLeaderboardByType(string type)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                var output = cnn.Query<Vehicle>("select * from Vehicle where Type = '" + type + "' order by FinishTime", new DynamicParameters());
                return output.ToList();
            }
        }

        internal static IEnumerable<Vehicle> GetVehiclesByRaceId(int raceId)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                var output = cnn.Query<Vehicle>("select * from Vehicle where RaceId = '" + raceId + "'", new DynamicParameters());
                return output.ToList();
            }
        }

        internal static IEnumerable<Vehicle> GetVehiclesByMultipleParameters(string team, string model, DateTime manufacturingDate, VehicleStatus status, int distance)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                var output = cnn.Query<Vehicle>("select * from Vehicle inner join VehicleStatistics on Vehicle.Id = VehicleStatistics.VehicleId " +
                    "where Vehicle.TeamName = '" + team + "' and Vehicle.Model = '" + model + "' and Vehicle.ManufacturingDate = '" + manufacturingDate + "' " +
                    "and Vehicle.Status = '" + status + "' and VehicleStatistics.Distance = '" + distance + "' order by Vehicle.Id", new DynamicParameters());
                return output.ToList();
            }
        }

        internal static void RemoveVehicleFromTheRace(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                cnn.Execute("update Vehicle set RaceId = 'NULL' where Id = '" + id + "'");
            }
        }
    }
}
