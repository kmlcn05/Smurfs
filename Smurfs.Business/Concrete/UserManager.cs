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
using Smurfs.Core.Abstract;

namespace Smurfs.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitofwork;
        public UserManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        //public void UserLogged(User user, String mail, String password)
        //{
        //    _unitofwork.UserLogin(mail, password);
        //}

        //public IDataResult<Task<User>> GetUserById(int id)
        //{
        //    return new SuccessDataResult<Task<User>>(_unitofwork.GetAsync(c => c.Id == id));
        //}

        //public IDataResult<Task<User>> GetMail(string mail)
        //{
        //    return new SuccessDataResult<Task<User>>(_unitofwork.GetAsync(c => c.Mail == mail));
        //}

        //public IDataResult<Task<User>> GetPassword(string password)
        //{
        //    return new SuccessDataResult<Task<User>>(_unitofwork.GetAsync(c => c.Password == password));
        //}

    }
}
