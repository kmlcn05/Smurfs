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
    public class CallStatusManager: ICallStatusService
    {

        private readonly IUnitOfWork _unitofwork;
        public CallStatusManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public void Create(CallStatus entity)
        {
            _unitofwork.CallStatus.Create(entity);
            _unitofwork.Save();
        }

        public void Delete(CallStatus entity)
        {
            _unitofwork.CallStatus.Delete(entity);
            _unitofwork.Save();
        }

        public async Task<List<CallStatus>> GetAll()
        {
            return await _unitofwork.CallStatus.GetAll();
        }

        public async Task<CallStatus> GetById(int id)
        {
            return await _unitofwork.CallStatus.GetById(id);
        }

        public void Update(CallStatus entity)
        {
            _unitofwork.CallStatus.Update(entity);
            _unitofwork.Save();
        }

        public Task<CallStatus> DeleteCallStatus(int id)
        {
            return _unitofwork.CallStatus.Delete2(id);
        }
    }
}
