using Microsoft.EntityFrameworkCore;
using Smurfs.Core.Concrete;
using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Concrete.Context;
using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Concrete
{
    public class BankDal : EfEntityRepositoryBase<Bank>, IBankDal
    {
        public BankDal(DbContext ctx) : base(ctx)
        {

        }
        private SmurfsContext SmurfsContext
        {
            get { return context as SmurfsContext; }
        }

        public async Task<Bank> DeleteBank(int id)
        {
            var result = await SmurfsContext.Banks
                .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                SmurfsContext.Banks.Remove(result);
                await SmurfsContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
