using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface IDZDStatusService
    {
        Task<DZDStatus> GetById(int id);
        Task<List<DZDStatus>> GetAll();
        void Create(DZDStatus entity);
        void Update(DZDStatus entity);
        void Delete(DZDStatus entity);
    }
}
