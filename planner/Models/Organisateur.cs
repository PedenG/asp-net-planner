using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planner.Models
{
    public class Organisateur : User
    {
        public string NomOrganisation { get; set; }
        public List<Evenement> EvenementsOrganises{ get; set; }

        public Organisateur()
        {

        }
    }
}
