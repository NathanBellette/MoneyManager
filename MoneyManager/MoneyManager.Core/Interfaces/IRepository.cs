using System;
using System.Linq;
using System.Linq.Expressions;

namespace MoneyManager.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includedProperties = "");

        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
    }
}