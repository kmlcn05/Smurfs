using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface ICallStatusService
    {
        Task<CallStatus> GetById(int id);
        Task<List<CallStatus>> GetAll();
        void Create(CallStatus entity);
        void Update(CallStatus entity);
        void Delete(CallStatus entity);

        Task<CallStatus> DeleteCallStatus(int id);
    }
}
