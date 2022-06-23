using Microsoft.EntityFrameworkCore;
using Smurfs.Core.Concrete;
using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Concrete.Context;
using Smurfs.Entity.Concrete;
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
    }
}
