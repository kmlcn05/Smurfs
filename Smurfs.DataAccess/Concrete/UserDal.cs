using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Abstract;

using System;
using Smurfs.DataAccess.Concrete.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Smurfs.Entities.Conrete;
using Smurfs.Core.Concrete;
using System.Linq.Expressions;

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

        User IUserDal.Get(Expression<Func<User, bool>> filter)
        {
            return SmurfsContext.Users.FirstOrDefault(filter);
        }
        //public bool UserLogin(String Mail, String Password)
        //{
        //    IQueryable<User> query = null;

        //    try
        //    {

        //        query = from u in SmurfsContext.Users
        //                where u.Mail == Mail && u.Password == Password
        //                select u;


        //        if (query.SingleOrDefault() != null)
        //        {
        //            return true;
        //        }


        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return false;

    }
}
