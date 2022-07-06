using Smurfs.Business.Abstract;
using Smurfs.Core.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Concrete
{
    public class PremiumManager: IPremiumService
    {

        private readonly IUnitOfWork _unitofwork;
        public PremiumManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public void Create(int Id, DateTime premiumDate, string name, string surname, string projectAmount = "0", string callAmount = "0")
        {
            var Premium = _unitofwork.Premium.AddPremium(Id, premiumDate, name, surname, projectAmount, callAmount);
            _unitofwork.Premium.Create(Premium);
            _unitofwork.Save();

        }

        public void Update(int Id, DateTime premiumDate, string name, string surname, string projectAmount = "0", string callAmount = "0")
        {
            var Premium = _unitofwork.Premium.AddPremium(Id, premiumDate, name, surname, projectAmount, callAmount);
            _unitofwork.Premium.Update(Premium);
            _unitofwork.Save();
        }

        public void Delete(Premium entity)
        {
            _unitofwork.Premium.Delete(entity);
            _unitofwork.Save();
        }

        public async Task<List<Premium>> GetAll()
        {
            return await _unitofwork.Premium.GetAll();
        }

        public async Task<Premium> GetById(int id)
        {
            return await _unitofwork.Premium.GetById(id);
        }

        public List<PremiumDto> PremiumDetails()
        {
            var Premium = _unitofwork.Premium.PremiumDetails();
            return Premium;
        }

        public Task<Premium> DeletePremium(int id)
        {
            return _unitofwork.Premium.DeletePremium(id);
        }
    }
}
