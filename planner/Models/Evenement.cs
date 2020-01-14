using planner.Ressource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace planner.Models
{
    public class Evenement
    {
        [Key]
        public int IdEvent { get; set; }
        public Organisateur Organisateur { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public DateTime DateHeureCreation{ get; set; }
        public DateTime DateHeureEvenement{ get; set; }
        public string Ville { get; set; }
        public string Cp { get; set; }
        public string Adresse { get; set; }
        // tag1;tag2;tag3;...
        public string Tags { get; set; }






        //public List<string> Commentaires { get; set; }

        public Evenement()
        {
            DateHeureCreation = DateTime.Now;
            //Evenement.EnoyerEvenement(new Evenement());
        }
        public static List<Evenement> GetEvents()
        {
            return new List<Evenement>() {new Evenement() {Titre="TOTO" } , new Evenement() { Titre = "TITI" } };
        }
        public static Evenement ModifEvent(Evenement e)
        {
            AspDbContext context = new AspDbContextFactory().CreateDbContext(null);
            context.Update(e); 
            return e;
        }
        public static void EnoyerEvenement(Evenement e)
        {
            AspDbContext context = new AspDbContextFactory().CreateDbContext(null);
            context.Add(e);
        }
    }
}
