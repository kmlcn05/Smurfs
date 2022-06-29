using Smurfs.Entities.Conrete;
using Smurfs.Entity.DTO_s;
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
        void Create(LogDto entity);
        void Update(LogDto entity);
        void Delete(Log entity);
        List<LogDto> LogDetails();

        Task<Log> DeleteLog(int id);
    }
}