using Microsoft.AspNetCore.Mvc;
using planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using planner.Ressource;

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
        public object Event(int id)
        {
            return Evenement.GetEvents().Where(x => x.IdEvent == id).ToList();
        }

        [HttpGet("Events/del/{id}")]
        [Produces("application/json")]
        public object DelEvent(int id)
        {
            var list = Evenement.GetEvents();
            list.RemoveAll(x => x.IdEvent == id);
            return list;
        }
        
        [HttpPost("Events/modif")]
        [Produces("application/json")]
        public object ModifEvent(int id)
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEnd();
                return Evenement.ModifEvent(JsonConvert.DeserializeObject<Evenement>(body));
            }
        }
        
        [HttpPost("Events/add")]
        [Produces("application/json")]
        public string AddEvent()
        {
            try
            {
                var body = GetBody();
                if (!string.IsNullOrWhiteSpace(body))
                {
                    DatabaseHelper dbHelper = new DatabaseHelper();
                    dbHelper.InsertObjToDB(JsonConvert.DeserializeObject<Evenement>(body));
                    return "succes";

                }
                else
                {
                    return "error";
                }
            }
            catch
            {

            }
            return "error";
        }
        public string GetBody()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                return reader.ReadToEnd();
            }
        }
    }
}

