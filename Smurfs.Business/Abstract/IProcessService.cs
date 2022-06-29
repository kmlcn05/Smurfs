using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface IProcessService
    {
        Task<Process> GetById(int id);
        Task<List<Process>> GetAll();
        void Create(Process entity);
        void Update(Process entity);
        void Delete(Process entity);
        Task<Process> DeleteProcess(int id);
    }
}
