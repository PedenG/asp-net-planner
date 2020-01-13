using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planner.Ressource
{
    public class DatabaseHelper
    {
        private string ApiUrl { get; set; }

        private DatabaseHelper()
        {

        }

        public static DatabaseHelper Instance(string api_url)
        {
            DatabaseHelper helper = new DatabaseHelper
            {
                ApiUrl = "https://"+api_url+"/"
            };
            return helper;
        }

        public void Get(string url)
        {

        }

        public void Supprimer(object o)
        {

        }
        public void Inserer(object o)
        {
            string url = ApiUrl+"/POST/"+o.GetType().Name;
        }

        public void LireUnique(object o)
        {
            
        }
        public void LireList(object o)
        {
            string url = ApiUrl + "/Get/" + o.GetType().Name;
        }
    }
}
