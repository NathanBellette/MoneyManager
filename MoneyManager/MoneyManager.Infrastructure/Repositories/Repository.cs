using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MoneyManager.Core.Interfaces;

namespace MoneyManager.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IMoneyManagerContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(IMoneyManagerContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, 
            IOrderedQueryable<T>> orderBy = null, string includedProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includedProperty in includedProperties.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includedProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            if (_context.Entry(entityToDelete).State == EntityState.Deleted)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }
    }
}