using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsyncTask();
        void Commit();
    }
}
