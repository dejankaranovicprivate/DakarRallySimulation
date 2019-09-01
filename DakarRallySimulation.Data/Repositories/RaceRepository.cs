using DakarRallySimulation.Data.Interfaces;
using DakarRallySimulation.Data.Models;
using DakarRallySimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallySimulation.Data.Repositories
{
    public class RaceRepository : IRaceRepository
    {
        public void AddRace(int year)
        {
            SqliteDataAccess.SaveRace(new Race
            {
                Distance = 10000,
                Status = RaceStatus.Pending,
                Year = year
            });
        }

        public void StartTheRace(int id)
        {
            SqliteDataAccess.StartTheRace(id);
        }

        public List<Race> GetAllRaces()
        {
            return SqliteDataAccess.GetRaces();
        }

        public Race GetRace(int id)
        {
            throw new NotImplementedException();
        }
    }
}
