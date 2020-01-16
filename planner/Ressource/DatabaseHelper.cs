using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var test = context.Add(o);
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
