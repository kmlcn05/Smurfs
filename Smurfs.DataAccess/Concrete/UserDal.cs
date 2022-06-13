using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Abstract;
using Smurfs.Core.Data.Concrete;

using System;
using Smurfs.DataAccess.Concrete.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Smurfs.Entities.Conrete;

namespace Smurfs.DataAccess.Concrete
{
    public class UserDal : EfEntityRepositoryBase<User>, IUserDal

    {

        public bool UserLogin(String Mail, String Password)
        {
            IQueryable<User> query = null;

            try
            {
                using (SmurfsContext context = new SmurfsContext())
                {
                    query = from u in context.Users
                            where u.Mail == Mail && u.Password == Password
                            select u;

                }
                if (query.SingleOrDefault() != null)
                {
                    return true;
                }


                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;

        }
    }
}
