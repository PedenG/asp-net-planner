using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace planner.Models
{
    public class Visisteur : User
    {
        [Key]
        public int IdVisiteur { get; set; }
        public string Login { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Port { get; set; }

        public DateTime DateInscription { get; set; }
        public List<Evenement> Evenements { get; set; }
        //public ICollection<string> Themes { get; set; }

        public Visisteur()
        {
            
        }
        public static List<Visisteur> GetVisits()
        {
            AspDbContext context = new AspDbContextFactory().CreateDbContext(null);
            return context.Visisteurs.ToList();
        }
    }
}
