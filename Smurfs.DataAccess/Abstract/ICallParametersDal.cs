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
    public interface ICallParametersDal : IEntityRepository<CallParameters>
    {
        public List<CallParametersDto> CallParametersDetails();

        public Task<CallParameters> DeleteCallParameters(int id);

        public CallParameters AddCallParameters(CallParametersDto callParameters);
    }
}
