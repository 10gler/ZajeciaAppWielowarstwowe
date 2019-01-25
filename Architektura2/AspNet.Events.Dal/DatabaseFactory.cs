using AspNet.Events.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Events.Dal
{
    public class DatabaseFactory : IDatabaseFactory, IDisposable
    {
        private EventContext _eventContext;
        private bool _disposed = false;

        public Models.EventContext Get()
        {
            return _eventContext ?? (_eventContext = new EventContext());
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _eventContext.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            if (_eventContext != null)
            {
                Dispose(true);
            }
        }
    }
}
