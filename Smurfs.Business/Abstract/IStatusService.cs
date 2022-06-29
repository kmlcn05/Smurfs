using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface IStatusService
    {
        Task<Status> GetById(int id);
        Task<List<Status>> GetAll();
        void Create(Status entity);
        void Update(Status entity);
        void Delete(Status entity);
        Task<Status> DeleteStatus(int id);
    }
}
