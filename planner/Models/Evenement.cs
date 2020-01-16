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
        public int? OrganisateurIdOrga { get; set; }
        
        public Organisateur Organisateur { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string DateHeureCreation{ get; set; }
        public string DateHeureEvenement { get; set; }
        public string Ville { get; set; }
        public string Cp { get; set; }
        public string Adresse { get; set; }
        public string Tags { get; set; }




        //public List<string> Commentaires { get; set; }

        public Evenement()
        {
            DateHeureCreation = DateTime.Now.ToString().Substring(0,10);
            //Evenement.EnoyerEvenement(new Evenement());
        }
        public static List<Evenement> GetEvents()
        {
            AspDbContext context = new AspDbContextFactory().CreateDbContext(null);
            return context.Evenements.ToList();
        }
        public static Evenement ModifEvent(Evenement e)
        {
            AspDbContext context = new AspDbContextFactory().CreateDbContext(null);
            context.Update(e);
            context.SaveChanges();
            return e;
        }
        public static void EnoyerEvenement(Evenement e)
        {
            AspDbContext context = new AspDbContextFactory().CreateDbContext(null);
            var test = context.Add(e);
            context.SaveChanges();
        }
    }
}
