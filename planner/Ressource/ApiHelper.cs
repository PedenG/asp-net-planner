using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planner.Ressource
{
    public class ApiHelper
    {
        private string ApiUrl { get; set; }

        private ApiHelper()
        {

        }

        public static ApiHelper Instance(string api_url)
        {
            ApiHelper helper = new ApiHelper
            {
                ApiUrl = "https://"+api_url+"/"
            };
            return helper;
        }

        public void Get(string url)
        {

        }

        public void Post(object o)
        {
            string url = ApiUrl+"/POST/"+o.GetType().Name;
        }

        public void Get(object o)
        {
            string url = ApiUrl + "/Get/" + o.GetType().Name;
        }
    }
}
