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
    public class CallDal : EfEntityRepositoryBase<Call>, ICallDal
    {
        public CallDal(DbContext ctx) : base(ctx)
        {

        }
        private SmurfsContext SmurfsContext
        {
            get { return context as SmurfsContext; }
        }

        public List<GetCallDto> GetCallDetails()
        {

            var result = from c in SmurfsContext.Calls
                         join b in SmurfsContext.Banks
                         on c.Bank.Id equals b.Id
                         join cs in SmurfsContext.CallStatus
                         on c.CallStatus.Id equals cs.Id
                         select new GetCallDto
                         { Id = c.Id, Bank = b.BankName, TaskType = c.TaskType, JiraTaskNo = c.JiraTaskNo, CallName = c.CallName, CagriCozumSuresi = c.CagriCozumSuresi, CallDetails = c.CallDetails, CallPriority = c.CallPriority, CallDateCreated = c.CallDateCreated, CallDateResolved = c.CallDateResolved, CallStatus = cs.CallStatusName, Appointee = c.Appointee, Reporter = c.Reporter, IsState = Convert.ToString(c.IsState) };
            return result.ToList();
        }

        public async Task<Call> DeleteCall(int id)
        {
            var result = await SmurfsContext.Calls
                .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                SmurfsContext.Calls.Remove(result);
                await SmurfsContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public Call AddCall(GetCallDto call)
        {
            var result = new Call();

            result.Id = call.Id;
            result.Bank = SmurfsContext.Banks.Single(a => a.BankName == call.Bank);
            result.TaskType = call.TaskType;
            result.JiraTaskNo = call.JiraTaskNo;
            result.CallName = call.CallName;
            result.CagriCozumSuresi = call.CagriCozumSuresi;
            result.CallDetails = call.CallDetails;
            result.CallPriority = call.CallPriority;
            result.CallDateCreated = call.CallDateCreated;
            result.CallDateResolved = call.CallDateResolved;
            result.CallStatus = SmurfsContext.CallStatus.Single(a => a.CallStatusName == call.CallStatus);
            result.Appointee = call.Appointee;
            result.Reporter = call.Reporter;
            result.IsState = Convert.ToBoolean(call.IsState);
            return result;
        }

    }








}

