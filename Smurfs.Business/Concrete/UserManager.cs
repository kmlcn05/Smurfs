using Smurfs.Business.Abstract; 
using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smurfs.Entities.Conrete;
using Core.Utilities.Results;
using Smurfs.Core.Abstract;
using Smurfs.Entity.DTO_s;

namespace Smurfs.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitofwork;
        public UserManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public void Create(UserDto entity)
        {
            var User = _unitofwork.User.AddUser(entity);
            _unitofwork.User.Create(User);
            _unitofwork.Save();
        }

        public void Update(UserDto entity)
        {
            var User = _unitofwork.User.AddUser(entity);
            _unitofwork.User.Update(User);
            _unitofwork.Save();
        }

        public void Delete(User entity)
        {
            _unitofwork.User.Delete(entity);
            _unitofwork.Save();
        }

        public async Task<List<User>> GetAll()
        {
            return await _unitofwork.User.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _unitofwork.User.GetById(id);
        }

        public List<UserDto> UserDetails()
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
