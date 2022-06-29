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
using System.Threading.Tasks;namespace Smurfs.DataAccess.Concrete
{
    public class UserDal : EfEntityRepositoryBase<User>, IUserDal
    {
        public UserDal(SmurfsContext context) : base(context)
        { }
        private SmurfsContext SmurfsContext
        {
            get { return context as SmurfsContext; }
        }
        User IUserDal.Get(Expression<Func<User, bool>> filter)
        {
            return SmurfsContext.Users.FirstOrDefault(filter);
        }
        public List<UserDto> UserDetails()
        {
            var result = from c in SmurfsContext.Users
                         join b in SmurfsContext.UserGroups
                         on c.usergroup.Id equals b.Id
                         join cs in SmurfsContext.Teams
                         on c.team.Id equals cs.Id
                         select new UserDto
                         {
                             Id = c.Id,
                             Name = c.Name,
                             Surname = c.Surname,
                             Mail = c.Mail,
                             Password = c.Password,
                             Active = Convert.ToString(c.Active),
                             DateOfStart = c.DateOfStart
                         };
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
            var result = new User(); result.Id = user.Id;
            result.Name = user.Name;
            result.Surname = user.Surname;
            result.Mail = user.Mail;
            result.Password = user.Password;
            result.Active = Convert.ToByte(user.Active);
            result.DateOfStart = user.DateOfStart;
            result.usergroup = SmurfsContext.UserGroups.Single(a => a.GroupName == user.usergroup);
            result.team = SmurfsContext.Teams.Single(a => a.TeamName == user.team); return result;
        }
        //public bool UserLogin(String Mail, String Password)
        //{
        //    IQueryable<User> query = null;        //    try
        //    {        //        query = from u in SmurfsContext.Users
        //                where u.Mail == Mail && u.Password == Password
        //                select u;
        //        if (query.SingleOrDefault() != null)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return false;    }
    }
}