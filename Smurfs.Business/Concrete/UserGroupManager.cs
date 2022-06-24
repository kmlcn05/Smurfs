using Smurfs.Business.Abstract;
using Smurfs.Core.Abstract;
using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Concrete
{
    public class UserGroupManager : IUserGroupService
    {
        private readonly IUnitOfWork _unitofwork;
        public UserGroupManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public void Create(UserGroup entity)
        {
            _unitofwork.UserGroup.Create(entity);
            _unitofwork.Save();
        }

        public void Delete(UserGroup entity)
        {
            _unitofwork.UserGroup.Delete(entity);
            _unitofwork.Save();
        }

        public async Task<List<UserGroup>> GetAll()
        {
            return await _unitofwork.UserGroup.GetAll();
        }

        public async Task<UserGroup> GetById(int id)
        {
            return await _unitofwork.UserGroup.GetById(id);
        }

        public void Update(UserGroup entity)
        {
            _unitofwork.UserGroup.Update(entity);
            _unitofwork.Save();
        }
    }
}
