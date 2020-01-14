using Newtonsoft.Json;
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
        public string Login { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Port { get; set; }

        public DateTime DateInscription { get; set; }
        public string NomOrganisation { get; set; }
        public List<Evenement> EvenementsOrganises{ get; set; }

        public Organisateur()
        {

        }
    }
}
