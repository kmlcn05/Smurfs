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
    public class DZDStatusManager: IDZDStatusService
    {

        private readonly IUnitOfWork _unitofwork;
        public DZDStatusManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public void Create(DZDStatus entity)
        {
            _unitofwork.DZDStatus.Create(entity);
            _unitofwork.Save();
        }

        public void Delete(DZDStatus entity)
        {
            _unitofwork.DZDStatus.Delete(entity);
            _unitofwork.Save();
        }

        public async Task<List<DZDStatus>> GetAll()
        {
            return await _unitofwork.DZDStatus.GetAll();
        }

        public async Task<DZDStatus> GetById(int id)
        {
            return await _unitofwork.DZDStatus.GetById(id);
        }

        public void Update(DZDStatus entity)
        {
            _unitofwork.DZDStatus.Update(entity);
            _unitofwork.Save();
        }
    }
}
