using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planner.Models
{
    public class User
    {
        public string Login{ get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Port { get; set; }

        public DateTime DateInscription { get; set; }

        public User()
        {

        }

        public User Instance(string nom,string prenom)
        {
            User u = new User
            {
                Nom = nom,
                Prenom = prenom,
                DateInscription = DateTime.Now
            };
            return u;
        }
    }
}
