using Smurfs.Business.Abstract; 
using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smurfs.Entities.Conrete;

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
    }
}
