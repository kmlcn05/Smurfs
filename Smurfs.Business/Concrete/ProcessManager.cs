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
    public class ProcessManager : IProcessService
    {
        private readonly IUnitOfWork _unitofwork;
        public ProcessManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public void Create(Process entity)
        {
            _unitofwork.Process.Create(entity);
            _unitofwork.Save();
        }

        public void Delete(Process entity)
        {
            _unitofwork.Process.Delete(entity);
            _unitofwork.Save();
        }

        public async Task<List<Process>> GetAll()
        {
            return await _unitofwork.Process.GetAll();
        }

        public async Task<Process> GetById(int id)
        {
            return await _unitofwork.Process.GetById(id);
        }

        public void Update(Process entity)
        {
            _unitofwork.Process.Update(entity);
            _unitofwork.Save();
        }
        public Task<Process> DeleteProcess(int id)
        {
            return _unitofwork.Process.Delete2(id);
        }
    }
}
