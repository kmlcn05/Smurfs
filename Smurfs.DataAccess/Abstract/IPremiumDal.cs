using Smurfs.Core.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Abstract
{
    public interface IPremiumDal: IEntityRepository<Premium>
    {
        public List<PremiumDto> PremiumDetails();

        public Task<Premium> DeletePremium(int id);

        public Premium AddPremium(PremiumDto premium);
    }
}
