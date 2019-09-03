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
    public static class RaceDataAccess
    {
        internal static void SaveRace(Race race)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnentionString()))
            {
                cnn.Execute("insert into Race (Distance, Status, Year) values (@Distance, @Status, @Year)", race);
            }
        }

        internal static void StartTheRace(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnentionString()))
            {
                cnn.Execute("update Race set Status = 'Running' where Id = '" + id + "';" +
                    " update Vehicle set Status = 'Running' where RaceId = '" + id + "'");
            }
        }

        internal static List<Race> GetRaces()
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnentionString()))
            {
                var output = cnn.Query<Race>("select * from Race", new DynamicParameters());
                return output.ToList();
            }
        }

        internal static Race GetRaceById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
