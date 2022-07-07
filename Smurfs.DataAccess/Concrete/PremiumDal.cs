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
                         { Id = p.Id, Amount = Convert.ToString(p.Amount),ProjectAmount= Convert.ToString(p.ProjectAmount),CallAmount= Convert.ToString(p.CallAmount), PremiumDate = p.PremiumDate, Name = b.Name, Surname = b.Surname };
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
        public Premium AddPremium(int Id,DateTime premiumDate,string name,string surname, string projectAmount="0", string callAmount="0")
        {
            var result = new Premium();

            result.Id = Id;
            result.Amount = Convert.ToDecimal(projectAmount) + Convert.ToDecimal(callAmount);
            result.ProjectAmount = Convert.ToDecimal(projectAmount);
            result.CallAmount = Convert.ToDecimal(callAmount);  
            result.PremiumDate =premiumDate;
            result.Users = SmurfsContext.Users.Single(a => a.Name ==name && a.Surname == surname);

            return result;
        }
    }
}