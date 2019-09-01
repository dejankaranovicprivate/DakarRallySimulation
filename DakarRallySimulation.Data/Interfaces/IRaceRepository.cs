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
        void StartTheRace(int id);
        List<Race> GetAllRaces();
        Race GetRace(int id);
    }
}
