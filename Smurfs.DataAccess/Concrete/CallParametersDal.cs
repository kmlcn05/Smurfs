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
                         join b in SmurfsContext.Calls
                         on c.Call.Id equals b.Id
                         select new CallParametersDto
                         { Id = c.Id, Name = c.Name, CallCarpani = Convert.ToString(c.CallCarpani), CallKapasite = Convert.ToString(c.CallKapasite), 
                         CallGerceklesen = Convert.ToString(c.CallGerceklesen), CallVerimYuzdesi = Convert.ToString(c.CallVerimYuzdesi), 
                         CallVerimDegeri = Convert.ToString(c.CallVerimDegeri), CallVerimSonucu = Convert.ToString(c.CallVerimSonucu) };
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
            result.Name = callParameters.Name;
            result.CallCarpani = Convert.ToInt32(callParameters.CallCarpani);
            result.CallKapasite = Convert.ToInt32(callParameters.CallKapasite);;
            result.CallGerceklesen = Convert.ToInt32(callParameters.CallGerceklesen);
            result.CallVerimYuzdesi = Convert.ToInt32(callParameters.CallVerimYuzdesi);
            result.CallVerimDegeri = Convert.ToInt32(callParameters.CallVerimDegeri);
            result.CallVerimSonucu = Convert.ToInt32(callParameters.CallVerimSonucu);
            result.Call = SmurfsContext.Calls.Single(a => a.CallName == callParameters.Call);

            return result;
        }
    }
}