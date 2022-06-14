using Core.Utilities.Results;
using Smurfs.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface ILoginService
    {
        public IDataResult<UserLoginModel> Login(UserLoginModel user);
    }
}
