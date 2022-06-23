using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface IDepartmentService
    {
        Task<Department> GetById(int id);
        Task<List<Department>> GetAll();
        void Create(Department entity);
        void Update(Department entity);
        void Delete(Department entity);
    }
}
