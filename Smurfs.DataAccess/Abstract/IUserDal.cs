using Smurfs.Core.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.DTO_s;
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
        public List<LoginUserDto> Get(Expression<Func<User, bool>> filter);

        public List<UserDto> UserDetails();

        public Task<User> DeleteUser(int id);

        public User AddUser(UserDto user);

    }
}
