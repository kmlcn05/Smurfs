using Smurfs.Entities.Conrete;

namespace Smurfs.Business.Abstract
{
    public interface IProjectService
    {
        Task<List<Project>> GetAll();

        Task<Project> GetById(int id);
        void Create(Project entity);

        void Update(Project entity);

        void Delete(Project entity);

        Project Calculate(long projectId);

    }
}
