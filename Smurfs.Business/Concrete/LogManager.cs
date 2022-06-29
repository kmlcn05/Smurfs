using Smurfs.Business.Abstract;
using Smurfs.Core.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Concrete
{
    public class LogManager : ILogService
    {

        private readonly IUnitOfWork _unitofwork;
        public LogManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public void Create(LogDto entity)
        {
            var Log = _unitofwork.Log.AddLog(entity);
            _unitofwork.Log.Create(Log);
            _unitofwork.Save();
        }

        public void Update(LogDto entity)
        {
            var Log = _unitofwork.Log.AddLog(entity);
            _unitofwork.Log.Update(Log);
            _unitofwork.Save();
        }

        public void Delete(Log entity)
        {
            
            _unitofwork.Log.Delete(entity);
            _unitofwork.Save();
        }


        public Task<Log> DeleteLog(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Log>> GetAll()
        {
            return await _unitofwork.Log.GetAll();
        }

        public async Task<Log> GetById(int id)
        {
            return await _unitofwork.Log.GetById(id);
        }

        public List<LogDto> LogDetails()
        {
            throw new NotImplementedException();
        }


       
    }
}
