using Microsoft.EntityFrameworkCore;
using Smurfs.Core.Concrete;
using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Concrete.Context;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Concrete
{
    public class PremiumDal : EfEntityRepositoryBase<Premium>, IPremiumDal
    {
        public PremiumDal(DbContext ctx) : base(ctx)
        {
        }
        private SmurfsContext SmurfsContext
        {
            get { return context as SmurfsContext; }
        }
        public List<PremiumDto> PremiumDetails()
        {

            var result = from p in SmurfsContext.Premiums
                         join b in SmurfsContext.Users
                         on p.Users.Id equals b.Id
                         select new PremiumDto
                         { Id = p.Id, Amount = Convert.ToString(p.Amount), PremiumDate = p.PremiumDate };
            return result.ToList();
        }

        public async Task<Premium> DeletePremium(int id)
        {
            var result = await SmurfsContext.Premiums
                .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                SmurfsContext.Premiums.Remove(result);
                await SmurfsContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public Premium AddPremium(PremiumDto premium)
        {
            var result = new Premium();

            result.Id = premium.Id;
            result.Amount = Convert.ToDecimal(premium.Amount);
            result.PremiumDate = premium.PremiumDate;
            result.Users = SmurfsContext.Users.Single(a => a.Name == premium.Users);

            return result;
        }
    }
}