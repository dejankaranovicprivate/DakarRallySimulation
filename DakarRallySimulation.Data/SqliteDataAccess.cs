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
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public static List<Race> GetRaces()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnentionString()))
            {
                var output = cnn.Query<Race>("select * from Race", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveRace(Race race)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnentionString()))
            {
                cnn.Execute("insert into Race (Distance, Status, Year) values (@Distance, @Status, @Year)", race);
            }
        }
    }
}
