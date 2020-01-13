using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planner.Models
{
    public class Visisteur : User
    {
        public List<Evenement> Evenements { get; set; }
        public List<string> Themes { get; set; }

        public Visisteur()
        {

        }
    }
}
