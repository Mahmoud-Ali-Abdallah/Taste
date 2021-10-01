using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Taste.DataAccessLayer.Data.Repository.IRepository;

namespace Taste.DataAccessLayer.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        internal DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            Context = context;
            dbSet = Context.Set<T>();
        }
        public virtual void Add(T model)
        {
            dbSet.Add(model);
            
        }

        public virtual T Get(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filterBy = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includedProperties = null
            )
        {
            IQueryable<T> query = dbSet;

            if (filterBy != null)
            {
                query = dbSet.Where(filterBy);
            }

            // include properties in comma seperated
            if (includedProperties != null)
            {
                foreach (var includeProperty in
                    includedProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public virtual T GetFirstOrDefault(Expression<Func<T, bool>> filterBy = null, string includedProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filterBy != null)
            {
                query = dbSet.Where(filterBy);
            }

            // include properties in comma seperated
            if (includedProperties != null)
            {
                foreach (var includeProperty in
                    includedProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }



        public virtual void Remove(int id)
        {
            var model = dbSet.Find(id);
            Remove(model);
        }


        protected void Remove(T model)
        {
            dbSet.Remove(model);
        }
    }
}
