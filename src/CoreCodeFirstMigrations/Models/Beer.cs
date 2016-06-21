using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoreCodeFirstMigrations.Models
{
    public class Beer
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100, ErrorMessage = "Beer name must be shorter than 100 characters.")]
        public string Name { get; set; }

        [MaxLength(100, ErrorMessage = "Brewery name must be shorter than 100 characters.")]
        public string BreweryName { get; set; }

        public int StyleId { get; set; }

        public Style Style { get; set; }
    }
}
