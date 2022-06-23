using Smurfs.Core.Abstract;
using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Concrete.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SmurfsContext _context;
        public UnitOfWork(SmurfsContext context)
        {
            _context = context;
        }

        private UserDal _userDal;
        private BankDal _bankDal;
        private ProjectDal _projectDal;

        private UserGroupDal _userGroupDal;
        private TeamDal _teamDal;
        private StatusDal _statusDal;
        private ProcessDal _processDal;
        private DZDStatusDal _dzdstatusDal;
        private PremiumDal _premiumDal;
        private LogDal _logDal;
        private DepartmentDal _departmentDal;
        private CallStatusDal _callStatusDal;
        private CallDal _callDal;


        public IUserDal User =>
             _userDal = _userDal ?? new UserDal(_context);
        public IUserGroupDal UserGroup =>
            _userGroupDal = _userGroupDal ?? new UserGroupDal(_context);
        public ITeamDal Team=>
            _teamDal = _teamDal ?? new TeamDal(_context);
        public IBankDal Bank =>
             _bankDal = _bankDal ?? new BankDal(_context);
        public IStatusDal Status=>
            _statusDal = _statusDal ?? new StatusDal(_context);
        public IProcessDal Process=>
            _processDal = _processDal ?? new ProcessDal(_context);  
        public IDZDStatusDal DZDStatus=>
            _dzdstatusDal = _dzdstatusDal ?? new DZDStatusDal(_context);  
        public IPremiumDal Premium=>
            _premiumDal = _premiumDal ?? new PremiumDal(_context);  
        public ILogDal Log =>
            _logDal = _logDal ?? new LogDal(_context);

        public IDepartmentDal Department =>
            _departmentDal = _departmentDal ?? new DepartmentDal(_context); 
        public ICallStatusDal CallStatus =>
            _callStatusDal = _callStatusDal ?? new CallStatusDal(_context);




        public IProjectDal Project =>
             _projectDal = _projectDal ?? new ProjectDal(_context);

        public ICallDal Call =>
             _callDal = _callDal ?? new CallDal(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
