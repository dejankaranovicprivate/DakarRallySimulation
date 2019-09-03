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

namespace DakarRallySimulation.Data.DbAdapter
{
    public class SqliteDataAccess
    {
        public static string LoadConnectionString(string id = "Default")
        {
            //return ConfigurationManager.ConnectionStrings[id].ConnectionString;
            return @"Data Source=.\DemoDB.db;Version=3;New=False;Compress=True";
        }
    }
}
