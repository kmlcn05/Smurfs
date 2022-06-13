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
        //private CallDal _callDal;

        public IUserDal User =>
             _userDal = _userDal ?? new UserDal(_context);

        public IBankDal Bank =>
             _bankDal = _bankDal ?? new BankDal(_context);

        //public ICallDal Call =>
        //     _callDal = _callDal ?? new CallDal(_context);

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
