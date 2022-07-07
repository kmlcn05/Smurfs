using Smurfs.Business.Abstract;
using Smurfs.Core.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.Concrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Concrete
{
    public class CallManager : ICallService
    {

        private readonly IUnitOfWork _unitofwork;
        public CallManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<List<Call>> GetAll()
        {
            return await _unitofwork.Call.GetAll();

        }
       

        public async Task<Call> GetById(int id)
        {
            return await _unitofwork.Call.GetById(id);
        }

        public void Create(GetCallDto entity)
        {
            var call = _unitofwork.Call.AddCall(entity);
            _unitofwork.Call.Create(call);
            _unitofwork.Save();           
        }
       

        public void Update(GetCallDto entity)
        {
            var call = _unitofwork.Call.AddCall(entity);
            _unitofwork.Call.Update(call);
            _unitofwork.Save();
        }
      

        public void Delete(Call entity)
        {
            _unitofwork.Call.Delete(entity);
            _unitofwork.Save();
        }
       
        public List<GetCallDto> GetCallDetails()
        {
            var call = _unitofwork.Call.GetCallDetails();
            return call;
        }

        public Task<Call> DeleteCall(int id)
        {
            return _unitofwork.Call.DeleteCall(id);
        }
    }
}
