﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Events.Dal
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
