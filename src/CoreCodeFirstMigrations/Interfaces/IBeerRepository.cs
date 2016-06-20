using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CoreCodeFirstMigrations.Models;

namespace CoreCodeFirstMigrations.Interfaces
{
    public interface IBeerRepository : IBaseRepository<Beer>
    {
    }
}
