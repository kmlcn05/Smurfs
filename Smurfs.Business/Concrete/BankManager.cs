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
    public class BankManager : IBankService
    {
        private readonly IUnitOfWork _unitofwork;
        public BankManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public void Create(Bank entity)
        {
            _unitofwork.Bank.Create(entity);
            _unitofwork.Save();
        }

        public void Delete(Bank entity)
        {
            _unitofwork.Bank.Delete(entity);
            _unitofwork.Save();
        }

        public Task<Bank> DeleteBank(int id)
        {
            return _unitofwork.Bank.DeleteBank(id);
        }

        public async Task<List<Bank>> GetAll()
        {
            return await _unitofwork.Bank.GetAll();
        }

        public async Task<Bank> GetById(int id)
        {
            return await _unitofwork.Bank.GetById(id);
        }

        public void Update(Bank entity)
        {
            _unitofwork.Bank.Update(entity);
            _unitofwork.Save();
        }
    }
}
