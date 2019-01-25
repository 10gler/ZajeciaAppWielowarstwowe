using AspNet.Events.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Events.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        private EventContext _context;
        private IDatabaseFactory _databaseFactory;
        private bool _disposed = false;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _context = _databaseFactory.Get();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
