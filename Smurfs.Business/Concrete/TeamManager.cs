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
    public class TeamManager : ITeamService
    {
        private readonly IUnitOfWork _unitofwork;
        public TeamManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public void Create(Team entity)
        {
            _unitofwork.Team.Create(entity);
            _unitofwork.Save();
        }

        public void Delete(Team entity)
        {
            _unitofwork.Team.Delete(entity);
            _unitofwork.Save();
        }

        public async Task<List<Team>> GetAll()
        {
            return await _unitofwork.Team.GetAll();
        }

        public async Task<Team> GetById(int id)
        {
            return await _unitofwork.Team.GetById(id);
        }

        public void Update(Team entity)
        {
            _unitofwork.Team.Update(entity);
            _unitofwork.Save();
        }
        public Task<Team> DeleteTeam(int id)
        {
            return _unitofwork.Team.Delete2(id);
        }
    }
}
