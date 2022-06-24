using Smurfs.Core.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.DTO_s;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Abstract
{

    public interface IProjectDal : IEntityRepository<Project>
    {
        public List<GetProjectsDto> GetProjectsDetails();
        public Task<Project> DeleteProject(int id);
        public Project AddProject(GetProjectsDto project);
    }



}
