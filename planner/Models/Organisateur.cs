using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace planner.Models
{
    public class Organisateur : User
    {
        [Key]
        public int IdOrga { get; set; }
        public string NomOrganisation { get; set; }
        public List<Evenement> EvenementsOrganises{ get; set; }

        public Organisateur()
        {

        }
    }
}
