using Smurfs.Entity.Concrete;
using Smurfs.Entity.DTO_s;

namespace Smurfs.Business.Abstract
{
    public interface IProjectParametersService
    {

        Task<List<ProjectParameters>> GetAllParameters();

        Task<ProjectParameters> GetByIdParameters(int id);

        void CreateParameters(ProjectParametersDto entity);

        void UpdateParameters(ProjectParametersDto entity);

        void DeleteParameters(ProjectParameters entity);
        public ProjectParameters Calculate(int callId);
        List<ProjectParametersDto> ProjectParametersDetails();

        Task<ProjectParameters> DeleteProjectParameters(int id);

    }
}