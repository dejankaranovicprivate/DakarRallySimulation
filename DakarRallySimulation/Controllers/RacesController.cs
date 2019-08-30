using DakarRallySimulation.Data.Interfaces;
using DakarRallySimulation.Data.Models;
using DakarRallySimulation.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DakarRallySimulation.Controllers
{
    public class RacesController : ApiController
    {
        //private IRaceRepository races = new RaceRepository();
        private IRaceRepository races;

        public RacesController(IRaceRepository _races)
        {
            this.races = _races;
        }

        // POST api/values
        public void Post([FromBody]int year)
        {
            races.AddRace(year);
        }

        // GET api/Races
        public IEnumerable<Race> Get()
        {
            return races.GetAllRaces();
        }

        // GET api/Races/5
        public IHttpActionResult Get(int id)
        {
            var race = races.GetRace(id);
            if (race == null)
            {
                return NotFound();
            }
            return Ok(race);
        }
    }
}
