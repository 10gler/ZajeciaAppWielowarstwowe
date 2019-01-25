using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Events.Dal.Repository
{
    public interface IRepository<T>
    {
        void Add(T entry);
        void AddRange(IEnumerable<T> entries);
        void Delete(T entry);
        void Delete(Expression<Func<T, bool>> query);
        void Update(T entry);

        T Get(int id);
        //!params i nawiasy []
        T Get(Expression<Func<T, bool>> single, params Expression<Func<T, object>>[] paths);
        //!T i object
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] paths);
    }
}
