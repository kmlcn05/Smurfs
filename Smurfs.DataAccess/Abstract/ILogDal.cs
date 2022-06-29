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
    public interface ILogDal: IEntityRepository<Log>
    {
        public List<LogDto> LogDetails();

        public Task<Log> DeleteLog(int id);

        public Log AddLog(LogDto log);
    }
}
