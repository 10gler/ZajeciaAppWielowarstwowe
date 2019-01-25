using AspNet.Events.Dal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AspNet.Events.Dal.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private IDbSet<T> _dbSet;
        EventContext _context;

        public RepositoryBase(IDatabaseFactory databaseFactory)
        {
            _context = databaseFactory.Get();
            _dbSet = _context.Set<T>(); //context.Set
        }

        public void Add(T entry)
        {
            _dbSet.Add(entry);
        }

        public void AddRange(IEnumerable<T> entries)
        {
            _context.Configuration.AutoDetectChangesEnabled = false;
            foreach (var item in entries)
            {
                _dbSet.Add(item);
            }
            _context.Configuration.AutoDetectChangesEnabled = true;
        }

        public void Delete(T entry)
        {
            //!
            if (_context.Entry(entry).State == EntityState.Detached)
            {
                _dbSet.Attach(entry);
            }
            _dbSet.Remove(entry);
        }

        public void Delete(System.Linq.Expressions.Expression<Func<T, bool>> query)
        {
            foreach (var item in _dbSet.Where(query))
            {
                Delete(item);
            }
        }

        public void Update(T entry)
        {
            //!
            _dbSet.Attach(entry);
            _context.Entry(entry).State = EntityState.Modified;
        }

        public T Get(int id)
        {
            //!
            return _dbSet.Find(id);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> single, params System.Linq.Expressions.Expression<Func<T, object>>[] paths)
        {
            return GetQueryWithInclude(paths).SingleOrDefault(single); //!
        }

        public IQueryable<T> GetAll(params System.Linq.Expressions.Expression<Func<T, object>>[] paths)
        {
            return GetQueryWithInclude(paths); //!
        }

        //!
        private IQueryable<T> GetQueryWithInclude(params Expression<Func<T, object>>[] paths)
        {
            if (paths!=null && paths.Any()) //!
            {
                foreach (var path in paths)
                {
                    _dbSet.Include(path);
                }
            }
            return _dbSet;
        }
    }
}