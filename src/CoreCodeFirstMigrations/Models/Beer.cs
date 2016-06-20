using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeFirstMigrations.Models
{
    public class Beer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string BreweryName { get; set; }
        public string Style { get; set; }
    }
}
