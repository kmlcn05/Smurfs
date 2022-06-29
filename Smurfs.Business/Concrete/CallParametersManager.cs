using Smurfs.Business.Abstract;
using Smurfs.Core.Abstract;
using Smurfs.Entity.Concrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Concrete
{
    public class CallParametersManager : ICallParametersService
    {
        private readonly IUnitOfWork _unitofwork;
        public CallParametersManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public async Task<List<CallParameters>> GetAllParameters()
        {
            return await _unitofwork.CallParameters.GetAll();

        }
        public async Task<CallParameters> GetByIdParameters(int id)
        {
            return await _unitofwork.CallParameters.GetById(id);
        }
        public void CreateParameters(CallParametersDto entity)
        {
            var CallParameters = _unitofwork.CallParameters.AddCallParameters(entity);
            _unitofwork.CallParameters.Create(CallParameters);
            _unitofwork.Save();
        }
        public void UpdateParameters(CallParametersDto entity)
        {
            var CallParameters = _unitofwork.CallParameters.AddCallParameters(entity);
            _unitofwork.CallParameters.Update(CallParameters);
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

        public List<CallParametersDto> CallParametersDetails()
        {
            var call = _unitofwork.CallParameters.CallParametersDetails();
            return call;
        }

        public Task<CallParameters> DeleteCallParameters(int id)
        {
            return _unitofwork.CallParameters.DeleteCallParameters(id);
        }

    }
}
