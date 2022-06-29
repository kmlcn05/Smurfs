using Smurfs.Core.Abstract;
using Smurfs.Entity.Concrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Abstract
{
    public interface IProjectParametersDal : IEntityRepository<ProjectParameters>
    {
        public List<ProjectParametersDto> ProjectParametersDetails();

        public Task<ProjectParameters> DeleteProjectParameters(int id);

        public ProjectParameters AddProjectParameters(ProjectParametersDto projectParameters);
    }
}
