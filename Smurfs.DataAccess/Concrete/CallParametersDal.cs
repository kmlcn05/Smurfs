using Microsoft.EntityFrameworkCore;
using Smurfs.Core.Concrete;
using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Concrete.Context;
using Smurfs.Entity.Concrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Concrete
{
    public class CallParametersDal : EfEntityRepositoryBase<CallParameters>, ICallParametersDal
    {
        public CallParametersDal(DbContext ctx) : base(ctx)
        {

        }
        private SmurfsContext SmurfsContext
        {
            get { return context as SmurfsContext; }
        }
        public List<CallParametersDto> CallParametersDetails()
        {

            var result = from c in SmurfsContext.CallParameters
                         select new CallParametersDto
                         { Id = c.Id, CallCarpani = Convert.ToString(c.CallCarpani), ParametersDate = c.ParametersDate };
            return result.ToList();
        }

        public async Task<CallParameters> DeleteCallParameters(int id)
        {
            var result = await SmurfsContext.CallParameters
                .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                SmurfsContext.CallParameters.Remove(result);
                await SmurfsContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public CallParameters AddCallParameters(CallParametersDto callParameters)
        {
            var result = new CallParameters();

            result.Id = callParameters.Id;
            result.ParametersDate = callParameters.ParametersDate;
            result.CallCarpani = Convert.ToInt32(callParameters.CallCarpani);

            return result;
        }
    }
}