using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace CoreCodeFirstMigrations.Models
{
    public class BreweryContext : DbContext
    {
        public BreweryContext(DbContextOptions<BreweryContext> options)
            : base(options)
        { }

        public DbSet<Beer> Beers { get; set; }
    }
}
