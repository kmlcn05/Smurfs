using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Abstract;

using System;
using Smurfs.DataAccess.Concrete.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Smurfs.Entities.Conrete;
using Smurfs.Core.Concrete;
using System.Linq.Expressions;
using Smurfs.Entity.DTO_s;
using System.Collections.Generic;

namespace Smurfs.DataAccess.Concrete
{
    public class UserDal : EfEntityRepositoryBase<User>, IUserDal

    {
        public UserDal(SmurfsContext context) : base(context)
        {

        }

        private SmurfsContext SmurfsContext
        {
            get { return context as SmurfsContext; }
        }

        public List<LoginUserDto> Get(Expression<Func<User, bool>> filter)
        {
            var user = SmurfsContext.Users.FirstOrDefault(filter);




            var loginuser = from u in SmurfsContext.Users
                            join ug in SmurfsContext.UserGroups
                            on u.usergroup.Id equals ug.Id
                            where u.Id == user.Id
                            select new LoginUserDto
                            {
                                Id = u.Id,
                                Name = u.Name,
                                Surname = u.Surname,
                                Mail = u.Mail,
                                UserGroup = ug.GroupName
                            };

            return loginuser.ToList();

        }
    }
}
