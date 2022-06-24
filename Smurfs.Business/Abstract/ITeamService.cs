using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface ITeamService
    {
        Task<Team> GetById(int id);
        Task<List<Team>> GetAll();
        void Create(Team entity);
        void Update(Team entity);
        void Delete(Team entity);
    }
}
