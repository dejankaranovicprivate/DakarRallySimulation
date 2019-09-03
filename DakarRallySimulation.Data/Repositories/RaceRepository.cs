using DakarRallySimulation.Data.DbAdapter;
using DakarRallySimulation.Data.Engine;
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
            RaceDataAccess.SaveRace(new Race
            {
                Status = RaceStatus.Pending,
                Year = year
            });
        }

        public void StartTheRace(int id)
        {
            RaceDataAccess.StartTheRace(id);
            VehiclesCalculations.VehiclesInRaceSimulation(id);
        }

        public List<Race> GetAllRaces()
        {
            return RaceDataAccess.GetRaces();
        }

        public Race GetRaceById(int id)
        {
            return RaceDataAccess.GetRaceById(id);
        }
    }
}
