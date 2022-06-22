using Core.Utilities.Results;
using Smurfs.Entities.Conrete;
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
        void Create(User entity);
        void Update(User entity);
        void Delete(User entity);
    }
}
