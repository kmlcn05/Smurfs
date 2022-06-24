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

        IUserGroupDal UserGroup { get; }
        ITeamDal Team { get; }   
        IStatusDal Status { get; }
        IProjectDal Project { get; }
        IProcessDal Process { get; }
        IDZDStatusDal DZDStatus { get; }
        IPremiumDal Premium { get; }    
        ILogDal Log { get; }    
        IDepartmentDal Department { get; }
        ICallStatusDal CallStatus { get; }
        ICallDal Call { get; }
        ICallParametersDal CallParameters { get; }


        void Save();
        Task<int> SaveAsync();
    }
}
