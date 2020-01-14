using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planner.Ressource
{
    public class DatabaseHelper
    {
        public DatabaseHelper()
        {

        }
        public bool InsertObjToDB(object o)
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
    }
}
