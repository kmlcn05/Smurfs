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
    public class StatusManager : IStatusService
    {
        private readonly IUnitOfWork _unitofwork;
        public StatusManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public void Create(Status entity)
        {
            _unitofwork.Status.Create(entity);
            _unitofwork.Save();
        }

        public void Delete(Status entity)
        {
            _unitofwork.Status.Delete(entity);
            _unitofwork.Save();
        }

        public async Task<List<Status>> GetAll()
        {
            return await _unitofwork.Status.GetAll();
        }

        public async Task<Status> GetById(int id)
        {
            return await _unitofwork.Status.GetById(id);
        }

        public void Update(Status entity)
        {
            _unitofwork.Status.Update(entity);
            _unitofwork.Save();
        }
    }
}
