using Smurfs.Entities.Conrete;
using Smurfs.Entity.Concrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface ICallService
    {
        Task<List<Call>> GetAll();

        Task<Call> GetById(int id);

        void Create(GetCallDto entity);

        void Update(GetCallDto entity);

        void Delete(Call entity);


        List<GetCallDto> GetCallDetails();

        Task<Call> DeleteCall(int id);

    }
}