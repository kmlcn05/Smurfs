using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface IBankService
    {
        Task<Bank> GetById(int id);
        Task<List<Bank>> GetAll();
        void Create(Bank entity);
        void Update(Bank entity);
        void Delete(Bank entity);
    }
}
