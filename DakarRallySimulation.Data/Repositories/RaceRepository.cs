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
        public List<Race> races = new List<Race>()
        {
            new Race { Id = 1, Distance = 10000, Status = RaceStatus.Pending, Year = 2019 },
            new Race { Id = 2, Distance = 10000, Status = RaceStatus.Pending, Year = 2020 }
        };

        // The solution is for demo purpose
        public void AddRace(int year)
        {
            races.Add(new Race
            {
                Id = races.LastOrDefault().Id + 1,
                Distance = 10000,
                Status = RaceStatus.Pending,
                Year = year
            });
        }

        public List<Race> GetAllRaces()
        {
            return races;
        }

        public Race GetRace(int id)
        {
            var race = races.FirstOrDefault(r => r.Id == id);
            return race;
        }
    }
}
