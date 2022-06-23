using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface ILogService
    {
        Task<Log> GetById(int id);
        Task<List<Log>> GetAll();
        void Create(Log entity);
        void Update(Log entity);
        void Delete(Log entity);
    }
}
