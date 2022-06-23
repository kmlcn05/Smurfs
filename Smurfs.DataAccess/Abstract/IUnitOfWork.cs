using Smurfs.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Core.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IUserDal User { get; }
        IBankDal Bank { get; }
        IProjectDal Project { get; }
        ICallDal Call { get; }

        void Save();
        Task<int> SaveAsync();
    }
}
