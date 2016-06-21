using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoreCodeFirstMigrations.Models
{
    public class Brewery
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100, ErrorMessage = "Brewery name must be less than 100 characters.")]
        public string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "Brewery description must be less than 1000 characters.")]
        public string Description { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }
    }
}
