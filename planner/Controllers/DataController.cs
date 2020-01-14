using Microsoft.AspNetCore.Mvc;
using planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace planner.Controllers
{
    [ApiController]
    [Route("API")]
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

        [HttpGet("Events/{id}")]
        [Produces("application/json")]
        public object Event(string titre)
        {
            return Evenement.GetEvents().Where(x => x.Titre.ToUpper() == titre.ToUpper()).ToList();
        }

        [HttpGet("Events/del/{id}")]
        [Produces("application/json")]
        public object DelEvent(string titre)
        {
            var list = Evenement.GetEvents();
            list.RemoveAll(x => x.Titre.ToUpper() == titre.ToUpper());
            return list;
        }
        
        [HttpGet("Events/modif/{id}")]
        [Produces("application/json")]
        public object ModifEvent(string titre)
        {
            var evenemnt = Evenement.GetEvents().Where(x => x.Titre == titre).ToList()[0];
            return Evenement.ModifEvent(evenemnt) != null ? Evenement.ModifEvent(evenemnt) : new Evenement();
        }
        
        [HttpGet("Events/add")]
        [Produces("application/json")]
        public string AddEvent(string titre)
        {
            using(var reader = new StreamReader(Request.Body)){
                var body = reader.ReadToEnd();
                Evenement.EnoyerEvenement(JsonConvert.DeserializeObject<Evenement>(body));
            }
            return "succes";
        }
    }
}

