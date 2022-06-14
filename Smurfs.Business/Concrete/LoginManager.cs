using Core.Utilities.Results;
using Smurfs.Business.Abstract;
using Smurfs.Core.Abstract;
using Smurfs.DataAccess.Models;
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
        public IDataResult<UserLoginModel> Login(UserLoginModel user)
        {
            var userToCheck = _unitOfWork.User.Get(u => u.Mail == user.Mail && u.Password == user.Password);
            if(userToCheck == null)
            {
                return new ErrorDataResult<UserLoginModel>("Wrong password or Mail");
            }
            return new SuccessDataResult<UserLoginModel>("Login is successful");

        }
    }
}
