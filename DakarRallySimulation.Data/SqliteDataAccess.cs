using DakarRallySimulation.Data.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallySimulation.Data
{
    public class SqliteDataAccess
    {
        private static string LoadConnentionString(string id = "Default")
        {
            //return ConfigurationManager.ConnectionStrings[id].ConnectionString;
            return @"Data Source=.\DemoDB.db;Version=3;New=False;Compress=True";
        }

        public static void SaveRace(Race race)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnentionString()))
            {
                cnn.Execute("insert into Race (Distance, Status, Year) values (@Distance, @Status, @Year)", race);
            }
        }

        public static void StartTheRace(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnentionString()))
            {
                cnn.Execute("update Race Status = 'Running' where Id = '" + id + "'");
            }
        }

        public static List<Race> GetRaces()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnentionString()))
            {
                var output = cnn.Query<Race>("select * from Race", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void AddVehicleToRace(Vehicle vehicle)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnentionString()))
            {
                vehicle.RaceId = Convert.ToInt32(cnn.ExecuteScalar("select Id from Race where Status='Pending'", new DynamicParameters()));

                cnn.Execute("insert into Vehicle (Status, TeamName, Model, ManufacturingDate, Type, " +
                    "MaxSpeed, RepairmentLast, ProbOfLightMalfunction, ProbOfHeavyMalfunction, FinishTime, RaceId) " +
                    "values (@Status, @TeamName, @Model, @ManufacturingDate, @Type, " +
                    "@MaxSpeed, @RepairmentLast, @ProbOfLightMalfunction, @ProbOfHeavyMalfunction, @FinishTime, @RaceId)", vehicle);
            }
        }

        public static void UpdateVehicleInfo(int id, Vehicle vehicle)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnentionString()))
            {
                cnn.Execute("update Vehicle Status = @Status, TeamName = @TeamName, Model = @Model, ManufacturingDate = @ManufacturingDate," +
                    " Type = @Type, MaxSpeed = @MaxSpeed, RepairmentLast = @RepairmentLast, ProbOfLightMalfunction = @ProbOfLightMalfunction, " +
                    "ProbOfHeavyMalfunction = @ProbOfHeavyMalfunction, FinishTime = @FinishTime, RaceId = @RaceId " +
                    "where Id = '" + id + "'", vehicle);
            }
        }

        public static List<Vehicle> GetVehiclesLeaderboard()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnentionString()))
            {
                var output = cnn.Query<Vehicle>("select * from Vehicle order by FinishTime", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void RemoveVehicleFromTheRace(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnentionString()))
            {
                cnn.Execute("update Vehicle RaceId = 'NULL' where Id = '" + id + "'");
            }
        }
    }
}
