using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Taste.DataAccessLayer.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filterBy = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includedProperties = null
            );

        T GetFirstOrDefault(
            Expression<Func<T, bool>> filterBy = null,
            string includedProperties = null
            );

        void Add(T model);

        void Remove(int id);
    }
}
