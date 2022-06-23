using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface IPremiumService
    {
        Task<Premium> GetById(int id);
        Task<List<Premium>> GetAll();
        void Create(Premium entity);
        void Update(Premium entity);
        void Delete(Premium entity);
    }
}
