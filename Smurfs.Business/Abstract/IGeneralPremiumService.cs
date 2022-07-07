using Smurfs.Entity.Concrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface IGeneralPremiumService
    {
        Task<GeneralPremium> GetById(int id);
        Task<List<GeneralPremium>> GetAll();
        void Create(int Id, DateTime premiumDate, string name, string surname, string projectAmount = "0", string callAmount = "0");
        void Update(int Id, DateTime premiumDate, string name, string surname, string projectAmount = "0", string callAmount = "0");
        void Delete(GeneralPremium entity);
        List<GeneralPremiumDto> GeneralPremiumDetails();
        Task<GeneralPremium> DeleteGeneralPremium(int id);
    }
}
