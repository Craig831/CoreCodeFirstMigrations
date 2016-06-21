using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CoreCodeFirstMigrations.Models;
using CoreCodeFirstMigrations.Interfaces;

namespace CoreCodeFirstMigrations.Repositories
{
    public class StyleRepository : BaseRepository<Style>, IStyleRepository
    {
        public StyleRepository(BreweryContext context)
            : base(context)
        { }
    }
}
