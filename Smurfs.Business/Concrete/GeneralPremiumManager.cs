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
    public class GeneralPremiumManager : IGeneralPremiumService
    {
        private readonly IUnitOfWork _unitofwork;
        public GeneralPremiumManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public void Create(int Id, DateTime premiumDate, string name, string surname, string projectAmount = "0", string callAmount = "0")
        {
            var GeneralPremium = _unitofwork.GeneralPremium.AddGeneralPremium(Id, premiumDate, name, surname, projectAmount, callAmount);
            _unitofwork.GeneralPremium.Create(GeneralPremium);
            _unitofwork.Save();

        }

        public void Update(int Id, DateTime premiumDate, string name, string surname, string projectAmount = "0", string callAmount = "0")
        {
            var GeneralPremium = _unitofwork.GeneralPremium.AddGeneralPremium(Id, premiumDate, name, surname, projectAmount, callAmount);
            _unitofwork.GeneralPremium.Update(GeneralPremium);
            _unitofwork.Save();
        }

        public void Delete(GeneralPremium entity)
        {
            _unitofwork.GeneralPremium.Delete(entity);
            _unitofwork.Save();
        }

        public async Task<List<GeneralPremium>> GetAll()
        {
            return await _unitofwork.GeneralPremium.GetAll();
        }

        public async Task<GeneralPremium> GetById(int id)
        {
            return await _unitofwork.GeneralPremium.GetById(id);
        }

        public List<GeneralPremiumDto> GeneralPremiumDetails()
        {
            var GeneralPremium = _unitofwork.GeneralPremium.GeneralPremiumDetails();
            return GeneralPremium;
        }

        public Task<GeneralPremium> DeleteGeneralPremium(int id)
        {
            return _unitofwork.GeneralPremium.DeleteGeneralPremium(id);
        }
    }
}
