using AspNet.Events.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Events.Dal
{
    public interface IDatabaseFactory
    {
        EventContext Get();
    }
}
