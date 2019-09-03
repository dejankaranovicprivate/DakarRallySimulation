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
    public class VehicleStatisticDataAccess
    {
        internal static void AddStatisticForVehicle(VehicleStatistics statistics)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                cnn.Execute("insert into VehicleStatistics (VehicleId, Distance, NumberOfLightMalfunctions, DoesHeavyMalfunctionsHappened, FinishTime) " +
                    "values (@VehicleId, @Distance, @NumberOfLightMalfunctions, @DoesHeavyMalfunctionsHappened, @FinishTime)", statistics);
            }
        }

        internal static VehicleStatistics GetStatisticForVehicle(int vehicleId)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                var output = cnn.Query<VehicleStatistics>("select * from VehicleStatistics where VehicleId = '" + vehicleId + "'", new DynamicParameters());
                return output.ToList()[0];
            }
        }
    }
}
