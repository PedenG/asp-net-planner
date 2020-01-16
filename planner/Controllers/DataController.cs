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
        [HttpGet("Events")]
        [Produces("application/json")]
        public object GetEvents()
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            return dbHelper.GetObjToDB(new Evenement());
        }

        [HttpGet("Events/{id}")]
        [Produces("application/json")]
        public object Event(int id)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            return dbHelper.GetOneObjFromDB<Evenement>(id);
        }

        [HttpGet("Events/del/{id}")]
        [Produces("application/json")]
        public object DelEvent(int id)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            return dbHelper.RemoveObjToDB(dbHelper.GetOneObjFromDB<Evenement>(id));
        }
        
        [HttpPost("Events/modif")]
        [Produces("application/json")]
        public object ModifEvent(int id)
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEnd();
                DatabaseHelper dbHelper = new DatabaseHelper();
                if (string.IsNullOrWhiteSpace(body))
                    return dbHelper.ModifObjToDB(dbHelper.GetOneObjFromDB<Evenement>(id));
                else
                    return dbHelper.ModifObjToDB(JsonConvert.DeserializeObject(body));
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
                    dbHelper.InsertObjToDB<Evenement>(JsonConvert.DeserializeObject<Evenement>(body));
                    return "succes";

                }
                else
                {
                    return "error";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        //===========================================================================================
        //Organisateur
        //==========================================================================================
        [HttpGet("Orgas")]
        [Produces("application/json")]
        public object GetOrga()
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            return dbHelper.GetObjToDB(new Organisateur());
        }

        [HttpGet("Orgas/{id}/Events")]
        [Produces("application/json")]
        public object OrgaEvents(int id)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            return (dbHelper.GetObjToDB(new Evenement()) as List<Evenement>).Where(x=>x.OrganisateurIdOrga == id).ToList();
        }

        [HttpGet("Orgas/{id}")]
        [Produces("application/json")]
        public object Orga(int id)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            return dbHelper.GetOneObjFromDB<Organisateur>(id);
        }

        [HttpGet("Orgas/del/{id}")]
        [Produces("application/json")]
        public object DelOrga(int id)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            return dbHelper.RemoveObjToDB(dbHelper.GetOneObjFromDB<Organisateur>(id));
        }
        
        [HttpPost("Orgas/modif")]
        [Produces("application/json")]
        public object ModifOrga(int id)
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEnd();
                DatabaseHelper dbHelper = new DatabaseHelper();
                if (string.IsNullOrWhiteSpace(body))
                    return dbHelper.ModifObjToDB(dbHelper.GetOneObjFromDB<Organisateur>(id));
                else
                    return dbHelper.ModifObjToDB(JsonConvert.DeserializeObject(body));
            }
        }
        
        [HttpPost("Orgas/add")]
        [Produces("application/json")]
        public string AddOrga()
        {
            try
            {
                var body = GetBody();
                if (!string.IsNullOrWhiteSpace(body))
                {
                    DatabaseHelper dbHelper = new DatabaseHelper();
                    dbHelper.InsertObjToDB<Organisateur>(JsonConvert.DeserializeObject<Organisateur>(body));
                    return "succes";
                }
                else
                {
                    return "error";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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

