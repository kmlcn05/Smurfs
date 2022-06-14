using Smurfs.DataAccess.Models;

namespace Smurfs.Business.Abstract
{
    public interface IProjectService
    {
        public void SaveProject(ProjectModel project);

        public void UpdateProject(ProjectModel project);


        public void DeleteProject(long projectId);
    }
}
