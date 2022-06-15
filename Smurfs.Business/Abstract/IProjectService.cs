using Smurfs.DataAccess.Models;
using Smurfs.Entities.Conrete;

namespace Smurfs.Business.Abstract
{
    public interface IProjectService
    {
        public List<Project> GetAllProjects();

        public Project GetProjectById(long projectId);
        public void SaveProject(Project project);

        public void UpdateProject(Project project);

        public void DeleteProject(long projectId);

        public Project Calculate(long projectId);
    }
}
