using Core.Utilities.Results;
using Smurfs.Business.Abstract;
using Smurfs.Core.Abstract;
using Smurfs.DataAccess.Models;
using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Concrete
{
    public class LoginManager : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoginManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IDataResult<User> Login(UserLoginModel user)
        {
            var userToCheck = _unitOfWork.User.Get(u => u.Mail == user.Mail && u.Password == user.Password );
            
            if(userToCheck == null)
            {
                return new ErrorDataResult<User>("Wrong password or Mail");
            }
            return new SuccessDataResult<User>(userToCheck, "Login is successful");

            

        }
    }
}
