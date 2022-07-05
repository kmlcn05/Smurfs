using Microsoft.EntityFrameworkCore;
using Smurfs.Core.Concrete;
using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Concrete.Context;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Concrete
{
    public class LogDal : EfEntityRepositoryBase<Log>, ILogDal
    {
        public LogDal(DbContext ctx) : base(ctx)
        {
        }
        private SmurfsContext SmurfsContext
        {
            get { return context as SmurfsContext; }
        }
        public List<LogDto> LogDetails()
        {
            var result = from p in SmurfsContext.Logs
                         join dz in SmurfsContext.Processes
                         on p.Process.Id equals dz.Id
                         join de in SmurfsContext.Users
                         on p.Users.Id equals de.Id
                         select new LogDto
                         { Id = p.Id, Page = p.Page, LogDate = p.LogDate, Process = dz.ProcessName, Name = de.Name,Surname = de.Surname };
            return result.ToList();
        }
        public async Task<Log> DeleteLog(int id)
        {
            var result = await SmurfsContext.Logs
              .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                SmurfsContext.Logs.Remove(result);
                await SmurfsContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public Log AddLog(LogDto log)
        {
            var result = new Log(); result.Id = log.Id;
            result.LogDate = log.LogDate;
            result.Page = log.Page;
            result.Process = SmurfsContext.Processes.Single(a => a.ProcessName == log.Process);
            result.Users = SmurfsContext.Users.Single(a => a.Name == log.Name && a.Surname == log.Surname);
            return result;
        }
    }
}