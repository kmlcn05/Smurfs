using Smurfs.Entity.Concrete;

namespace Smurfs.Business.Abstract
{
    public interface IProjectParametersService
    {

        Task<List<ProjectParameters>> GetAllParameters();

        Task<ProjectParameters> GetByIdParameters(int id);

        void CreateParameters(ProjectParameters entity);

        void UpdateParameters(ProjectParameters entity);

        void DeleteParameters(ProjectParameters entity);
        public ProjectParameters Calculate(int callId);



    }
}
