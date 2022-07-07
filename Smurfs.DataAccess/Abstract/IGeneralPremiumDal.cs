using Smurfs.Core.Abstract;
using Smurfs.Entity.Concrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Abstract
{
    public interface IGeneralPremiumDal : IEntityRepository<GeneralPremium>
    {
        public List<GeneralPremiumDto> GeneralPremiumDetails();

        public Task<GeneralPremium> DeleteGeneralPremium(int id);

        public GeneralPremium AddGeneralPremium(int Id, DateTime premiumDate, string name, string surname, string projectAmount = "0", string callAmount = "0");

    }
}
