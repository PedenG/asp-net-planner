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
    [Route("api")]
    [Produces("application/json")]
    public class DataController : ControllerBase
    {
        //===========================================================================================
        //Evenement
        //==========================================================================================
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
            return Evenement.GetEvents().Where(x => x.Titre == titre).ToList();
        }

        [HttpGet("Events/del/{titre}")]
        [Produces("application/json")]
        public object DelEvent(string titre)
        {
            var list = Evenement.GetEvents();
            list.RemoveAll(x => x.Titre.ToUpper() == titre.ToUpper());
            return list;
        }
        
        [HttpGet("Events/modif/{titre}")]
        [Produces("application/json")]
        public object ModifEvent(string titre)
        {
            var evenemnt = Evenement.GetEvents().Where(x => x.Titre == titre).ToList()[0];
            return Evenement.ModifEvent(evenemnt) != null ? Evenement.ModifEvent(evenemnt) : new Evenement();
        }
    }
}
