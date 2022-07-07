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
        public void Calculate(int cagricarpanı)
        {
            var users = _unitofwork.User.UserDetails();
            var call = _unitofwork.Call.GetCallDetails();
            var parametre = _unitofwork.CallParameters.CallParametersDetails();
            
            foreach (var user in users)
            {
                var gerceklesen = 0;
                var month = 0;
                var fark = 0;
                var kapasite = 0;
                var carpan = "";
                var verimyüzdesi = 0;
                var verimdeger = 0;
                var verimsonucu = 0;
                
                foreach (var c in call)
                {
                    if (user.Name + " " + user.Surname ==c.Appointee && c.IsState=="0")
                    {
                        if (c.CallStatus == "Closed")
                        {
                            gerceklesen++;  // bir proje bir defa dahil edilme kontrolü   
                        }
                    }
                }
                month = Convert.ToDateTime(user.DateOfStart).Month;
                fark = DateTime.Now.Month - month;
                kapasite = fark * 3; //her ay üç çağrı çözmek diye baz alınmış 
                carpan = parametre[0].CallCarpani;
                verimyüzdesi = (gerceklesen / kapasite) * 100;
                verimdeger = gerceklesen - kapasite;
                if (verimdeger < 0)
                {
                    verimdeger = 0;
                }
                verimsonucu = verimdeger * int.Parse(carpan);
                if (verimsonucu > 0)
                {
                    var result1 = _unitofwork.Premium.AddPremium(Id:0,premiumDate:DateTime.Now,name:user.Name,surname:user.Surname,callAmount:verimsonucu.ToString());
                    _unitofwork.Premium.Create(result1);
                    _unitofwork.Save();

                    var result2 = _unitofwork.GeneralPremium.AddGeneralPremium(Id:0,premiumDate:DateTime.Now,name:user.Name,surname:user.Surname,callAmount:verimsonucu.ToString());
                    _unitofwork.GeneralPremium.Create(result2);
                    _unitofwork.Save();
                }
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
