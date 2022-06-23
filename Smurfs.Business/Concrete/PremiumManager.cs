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
    public class PremiumManager: IPremiumService
    {

        private readonly IUnitOfWork _unitofwork;
        public PremiumManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public void Create(Premium entity)
        {
            _unitofwork.Premium.Create(entity);
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

        public void Update(Premium entity)
        {
            _unitofwork.Premium.Update(entity);
            _unitofwork.Save();
        }
    }
}
