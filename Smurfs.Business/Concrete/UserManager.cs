using Smurfs.Business.Abstract; 
using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smurfs.Entities.Conrete;
using Core.Utilities.Results;

namespace Smurfs.Business.Concrete
{
    internal class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void UserLogged(User user,String mail,String password) 
        {
            _userDal.UserLogin( mail,password);
        }

        public IDataResult<Task<User>> GetUserById(int id)
        {
            return new SuccessDataResult<Task<User>>(_userDal.GetAsync(c => c.Id ==id)); 
        }

        public IDataResult<Task<User>> GetMail(string mail)
        {
            return new SuccessDataResult<Task<User>>(_userDal.GetAsync(c => c.Mail == mail));
        }

        public IDataResult<Task<User>> GetPassword(string password)
        {
            return new SuccessDataResult<Task<User>>(_userDal.GetAsync(c => c.Password == password));
        }

    }
}
