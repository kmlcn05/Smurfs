using Smurfs.Entities.Conrete;
using Smurfs.Entity.Concrete;
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
       

        void Create(Call entity);
       

        void Update(Call entity);
       

        void Delete(Call entity);
       
        


    }
}
