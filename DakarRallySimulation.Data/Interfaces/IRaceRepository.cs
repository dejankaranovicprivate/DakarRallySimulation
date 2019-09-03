using DakarRallySimulation.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallySimulation.Data.Interfaces
{
    public interface IRaceRepository
    {
        void AddRace(int year);
        List<Race> GetAllRaces();
        Race GetRaceById(int id);
        void StartTheRace(int id);
    }
}
