using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using planner.Models;
namespace planner.Ressource
{
    public class DatabaseHelper
    {
        public DatabaseHelper()
        {

        }

        public bool InsertObjToDB<T>(object o)
        {
            AspDbContext context = new AspDbContextFactory().CreateDbContext(null);
            string query;
            switch (typeof(T).Name)
            {
                case ("Evenement"):
                    Evenement e = o as Evenement;
                    query = string.Format("INSERT INTO dbo.Evenement (Adresse,Cp,DateHeureCreation,DateHeureEvenement,Description,OrganisateurIdOrga,Tags,Titre,Ville) values ('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}','{8}')", e.Adresse, e.Cp, e.DateHeureCreation.ToString().Substring(0, 10), e.DateHeureEvenement.ToString().Substring(0,10), e.Description, 1, e.Tags, e.Titre, e.Ville);
                    context.Database.ExecuteSqlCommand(query);
                    break;
                case ("Organisateur"):
                    Organisateur or = o as Organisateur;
                    query = string.Format("INSERT INTO dbo.Organisateur (Login, Nom, Prenom, Email, Tel, Port, DateInscription, NomOrganisation, EvenementsOrganises) VALUE ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", or.Login, or.Nom, , or.Prenom, or.Email, or.Tel, or.Port, or.DateInscription.ToString().Substring(0, 10), or.NomOrganisation, or.EvenementsOrganises);
                    context.Database.ExecuteSqlCommand(query);
                    break;
                case ("Visiteur"):
                    break;
            }
            if(context.SaveChanges() == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public object GetOneObjFromDB<T>(int  id)
        {
            switch (typeof(T).Name)
            {
                case ("Evenement"):
                    return Evenement.GetEvents().Where(x => x.IdEvent == id);
                case ("Organisateur"):
                   return Organisateur.GetOrgas().Where(x => x.IdOrga == id);
                case ("Visiteur"):
                    return Visisteur.GetVisits().Where(x => x.IdVisiteur == id);
                default:
                    return null;
            }
        }
        public object GetObjToDB(object o)
        {
            switch (o.GetType().Name)
            {
                case ("Evenement"):
                    return Evenement.GetEvents();
                case ("Organisateur"):
                   return Organisateur.GetOrgas();
                case ("Visiteur"):
                    return Visisteur.GetVisits();
                default:
                    return null;
            }
        }
        public object RemoveObjToDB(object o)
        {
            AspDbContext context = new AspDbContextFactory().CreateDbContext(null);
            var test = context.Remove(o);
            if(context.SaveChanges() == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public object ModifObjToDB(object o)
        {
            AspDbContext context = new AspDbContextFactory().CreateDbContext(null);
            var test = context.Update(o);
            if(context.SaveChanges() == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
