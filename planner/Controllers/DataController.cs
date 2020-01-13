using Microsoft.AspNetCore.Mvc;
using planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planner.Controllers
{
    [ApiController]
    [Route("api")]
    [Produces("application/json")]
    public class DataController : ControllerBase
    {
        // GET api/fdp
        [HttpGet("Events")]
        public string Get(string alias)
        {
            return Evenement.GetEvents().ToString();
        }
    }
}
