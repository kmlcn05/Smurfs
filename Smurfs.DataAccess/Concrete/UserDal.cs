using Smurfs.DataAccess.Abstract;
using System;
using Smurfs.DataAccess.Concrete.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Smurfs.Entities.Conrete;
using Smurfs.Core.Concrete;
using System.Linq.Expressions;
using System.Collections.Generic;
using Smurfs.Entity.DTO_s;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Concrete
{
    public class UserDal : EfEntityRepositoryBase<User>, IUserDal
    {
        public UserDal(SmurfsContext context) : base(context)
        { }
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
        public List<UserDto> UserDetails()
        {

            var result = from c in SmurfsContext.Users
                         join b in SmurfsContext.UserGroups
                         on c.usergroup.Id equals b.Id
                         join cs in SmurfsContext.Teams
                         on c.team.Id equals cs.Id
                         select new UserDto
                         { Id = c.Id, Name = c.Name, Surname = c.Surname, Mail = c.Mail, Password = c.Password, Active = Convert.ToString(c.Active), DateOfStart = c.DateOfStart, team = cs.TeamName, usergroup = b.GroupName };
            return result.ToList();
        }

        public async Task<User> DeleteUser(int id)
        {
            var result = await SmurfsContext.Users
                .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                SmurfsContext.Users.Remove(result);
                await SmurfsContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public User AddUser(UserDto user)
        {
            var result = new User();

            result.Id = user.Id;
            result.Name = user.Name;
            result.Surname = user.Surname;
            result.Mail = user.Mail;
            result.Password = user.Password;
            result.Active = Convert.ToByte(user.Active);
            result.DateOfStart = user.DateOfStart;
            result.usergroup = SmurfsContext.UserGroups.Single(a => a.GroupName == user.usergroup);
            result.team = SmurfsContext.Teams.Single(a => a.TeamName == user.team);

            return result;
        }
    }
}
