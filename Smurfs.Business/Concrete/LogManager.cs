using Smurfs.Business.Abstract;
using Smurfs.Core.Abstract;
using Smurfs.Entities.Conrete;
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
        public void Create(Log entity)
        {
            _unitofwork.Log.Create(entity);
            _unitofwork.Save();
        }

        public void Delete(Log entity)
        {
            _unitofwork.Log.Delete(entity);
            _unitofwork.Save();
        }

        public async Task<List<Log>> GetAll()
        {
            return await _unitofwork.Log.GetAll();
        }

        public async Task<Log> GetById(int id)
        {
            return await _unitofwork.Log.GetById(id);
        }

        public void Update(Log entity)
        {
            _unitofwork.Log.Update(entity);
            _unitofwork.Save();
        }
    }
}
