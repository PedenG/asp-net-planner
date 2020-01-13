using chatbox.Ressource;
using planner.Ressource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planner.Models
{
    public class Evenement
    {
        public Organisateur Organisateur { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public DateTime DateHeureCreation{ get; set; }
        public DateTime DateHeureEvenement{ get; set; }
        public string Ville { get; set; }
        public string Cp { get; set; }
        public string Adresse { get; set; }
        public List<string> Tags { get; set; }






        public List<string> Commentaires { get; set; }

        public Evenement()
        {

        }

        public void EnoyerEvenement(Evenement e)
        {
            ApiHelper helper = ApiHelper.Instance("localhost");
            helper.Post(e);
        }
    }
}
