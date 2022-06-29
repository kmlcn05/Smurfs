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
    public class DepartmentManager: IDepartmentService
    {

        private readonly IUnitOfWork _unitofwork;
        public DepartmentManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public void Create(Department entity)
        {
            _unitofwork.Department.Create(entity);
            _unitofwork.Save();
        }

        public void Delete(Department entity)
        {
            _unitofwork.Department.Delete(entity);
            _unitofwork.Save();
        }

        public async Task<List<Department>> GetAll()
        {
            return await _unitofwork.Department.GetAll();
        }

        public async Task<Department> GetById(int id)
        {
            return await _unitofwork.Department.GetById(id);
        }

        public void Update(Department entity)
        {
            _unitofwork.Department.Update(entity);
            _unitofwork.Save();
        }
        public Task<Department> DeleteDepartment(int id)
        {
            return _unitofwork.Department.Delete2(id);
        }
    }
}
