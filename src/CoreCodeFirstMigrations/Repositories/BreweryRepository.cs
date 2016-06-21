using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CoreCodeFirstMigrations.Models;
using CoreCodeFirstMigrations.Interfaces;

namespace CoreCodeFirstMigrations.Repositories
{
    public class BreweryRepository : BaseRepository<Brewery>, IBreweryRepository
    {
        public BreweryRepository(BreweryContext context)
            : base(context)
        { }
    }
}
