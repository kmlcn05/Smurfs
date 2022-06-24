using Smurfs.Entities.Conrete;
using Smurfs.Entity.Concrete;
using Smurfs.Entity.DTO_s;


namespace Smurfs.Business.Abstract
{
    public interface IProjectService
    {
        Task<List<Project>> GetAll();

        Task<Project> GetById(int id);
        void Create(GetProjectsDto entity);

        void Update(GetProjectsDto entity);

        void Delete(Project entity);

        public ProjectParameters Calculate(int projectId);
        List<GetProjectsDto> GetProjectsDetails();

        Task<Project> DeleteProject(int id);
    }
}
