using Smurfs.Core.Abstract;
using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        //public bool UserLogin(String Mail, String Password);
        User Get(Expression<Func<User, bool>> filter);


    }
}
