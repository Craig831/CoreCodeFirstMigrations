using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CoreCodeFirstMigrations.Models;
using CoreCodeFirstMigrations.Interfaces;

namespace CoreCodeFirstMigrations.Repositories
{
    public class BeerRepository : BaseRepository<Beer>, IBeerRepository
    {
        public BeerRepository(BreweryContext context)
            : base(context)
        { }
    }
}
