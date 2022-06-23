using Smurfs.Business.Abstract;
using Smurfs.Core.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.Concrete;
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
        public async Task<List<CallParameters>> GetAllParameters()
        {
            return await _unitofwork.CallParameters.GetAll();

        }

        public async Task<Call> GetById(int id)
        {
            return await _unitofwork.Call.GetById(id);
        }
        public async Task<CallParameters> GetByIdParameters(int id)
        {
            return await _unitofwork.CallParameters.GetById(id);
        }

        public void Create(Call entity)
        {
            _unitofwork.Call.Create(entity);
            _unitofwork.Save();
        }
        public void CreateParameters(CallParameters entity)
        {
            _unitofwork.CallParameters.Create(entity);
            _unitofwork.Save();
        }

        public void Update(Call entity)
        {
            _unitofwork.Call.Update(entity);
            _unitofwork.Save();
        }
        public void UpdateParameters(CallParameters entity)
        {
            _unitofwork.CallParameters.Update(entity);
            _unitofwork.Save();
        }

        public void Delete(Call entity)
        {
            _unitofwork.Call.Delete(entity);
            _unitofwork.Save();
        }
        public void DeleteParameters(CallParameters entity)
        {
            _unitofwork.CallParameters.Delete(entity);
            _unitofwork.Save();
        }
        public CallParameters Calculate(int callId)
        {
            var call = _unitofwork.Call.GetById(callId);
            if (call != null)
            {
                CallParameters callParameter = new CallParameters();
                callParameter.CallVerimYuzdesi = (callParameter.CallGerceklesen / callParameter.CallKapasite) * 100;
                callParameter.CallVerimDegeri = (callParameter.CallGerceklesen - callParameter.CallKapasite);

                if (callParameter.CallVerimDegeri < 0)
                {
                    callParameter.CallVerimDegeri = 0;
                }
                else
                {
                    callParameter.CallVerimDegeri = callParameter.CallVerimDegeri;
                }
                callParameter.CallVerimSonucu = (callParameter.CallVerimDegeri * callParameter.CallCarpani);

                CallParameters callhesap = new CallParameters();
                callhesap = callParameter;

                return callhesap;
            }
            else
            {
                throw new Exception("Call Not found!");
            }

        }
    }
}
