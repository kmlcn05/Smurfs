using Core.Utilities.Results;
using Smurfs.DataAccess.Models;
using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface ILoginService
    {
        public User Login(UserLoginModel user);
    }
}
