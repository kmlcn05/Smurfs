using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface IUserGroupService
    {
        Task<UserGroup> GetById(int id);
        Task<List<UserGroup>> GetAll();
        void Create(UserGroup entity);
        void Update(UserGroup entity);
        void Delete(UserGroup entity);
    }
}
