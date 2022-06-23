using Microsoft.EntityFrameworkCore;
using Smurfs.Core.Abstract;
using Smurfs.Core.Concrete;
using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Abstract
{
    public interface IUserGroupDal : IEntityRepository<UserGroup>
    {

    }
}
