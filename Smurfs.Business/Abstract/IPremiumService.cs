
using Smurfs.Entities.Conrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Smurfs.Business.Abstract
{
    public interface IPremiumService
    {
        Task<Premium> GetById(int id);
        Task<List<Premium>> GetAll();
        void Create(PremiumDto entity);
        void Update(PremiumDto entity);
        void Delete(Premium entity);
        List<PremiumDto> PremiumDetails();
        Task<Premium> DeletePremium(int id);
    }
}

