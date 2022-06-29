using Core.Utilities.Results;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface IUserService
    {
        Task<User> GetById(int id);
        Task<List<User>> GetAll();
        void Create(UserDto entity);
        void Update(UserDto entity);
        void Delete(User entity);
        List<UserDto> UserDetails();

        Task<User> DeleteUser(int id);
    }
}