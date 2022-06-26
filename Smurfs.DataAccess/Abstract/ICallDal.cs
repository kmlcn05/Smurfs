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
    public interface ICallDal : IEntityRepository<Call>
    {
        public List<GetCallDto> GetCallDetails();
        public Task<Call> DeleteCall(int id);
        public Call AddCall(GetCallDto call);
    }
}

