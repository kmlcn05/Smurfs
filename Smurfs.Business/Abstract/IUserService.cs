using Core.Utilities.Results;
using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface IUserService
    {
        public void UserLogged(User user,String mail,String password);

        IDataResult<Task<User>> GetUserById(int id);
        IDataResult<Task<User>> GetMail(String mail);
        IDataResult<Task<User>> GetPassword(String password);
    }
}
