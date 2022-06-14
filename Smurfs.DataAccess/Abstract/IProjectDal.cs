using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Abstract
{
    public interface IProjectDal
    {
        public List<Project>? GetAllProjects();

        public Project? GetProjectById(long projectId);

        public void SaveProject(Project project);

        public void UpdateProject(Project project);

        public void DeleteProject(Project project);

    }
}
