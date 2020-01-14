using Microsoft.AspNetCore.Mvc;
using planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace planner.Controllers
{
    [ApiController]
    [Route("API")]
    [Produces("application/json")]
    public class DataController : ControllerBase
    {
        // GET api/fdp
        [HttpGet("Events")]
        [Produces("application/json")]
        public object Get()
        {
            var listEvent = Evenement.GetEvents();
            return listEvent;
        }

        [HttpGet("Events/{titre}")]
        [Produces("application/json")]
        public object Event(string titre)
        {
            return Evenement.GetEvents().Where(x => x.Titre.ToUpper() == titre.ToUpper()).ToList();
        }
    }
}

