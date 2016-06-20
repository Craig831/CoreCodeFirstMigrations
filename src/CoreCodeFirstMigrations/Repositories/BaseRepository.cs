using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using CoreCodeFirstMigrations.Interfaces;
using CoreCodeFirstMigrations.Models;

namespace CoreCodeFirstMigrations.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        private readonly BreweryContext _context;

        public BaseRepository(BreweryContext context)
        {
            _context = context;
        }

        public BreweryContext Context
        {
            get
            {
                return this._context;
            }
        }

        public virtual IEnumerable<T> Get()
        {
            return this.Context.Set<T>();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return this.Context.Set<T>().Where(predicate);
        }

        public virtual void Insert(T entity)
        {
            this.Context.Set<T>().Add(entity);
            this.Context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            //this.Context.Entry(entity).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        //public virtual void Attach(T entity)
        //{
        //    if(this.Context.Entry(entity).State == EntityState.Detached)
        //    {
        //        this.Context.Set<T>().Attach(entity);
        //    }
        //}

        public virtual void Delete(T entity)
        {
            this.Context.Set<T>().Remove(entity);
            this.Context.SaveChanges();
        }

    }
}
