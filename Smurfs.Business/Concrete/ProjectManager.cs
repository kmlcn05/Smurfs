using Smurfs.Business.Abstract;
using Smurfs.Core.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.Concrete;
using Smurfs.Entity.DTO_s;

namespace Smurfs.Business.Concrete
{
    public class ProjectManager : IProjectService
    {

        private readonly IUnitOfWork _unitofwork;
        public ProjectManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<List<Project>> GetAll()
        {
            return await _unitofwork.Project.GetAll();

        }

        public async Task<Project> GetById(int id)
        {
            return await _unitofwork.Project.GetById(id);
        }

        public void Create(GetProjectsDto entity)
        {
            var project = _unitofwork.Project.AddProject(entity);
            _unitofwork.Project.Create(project);
            _unitofwork.Save();
        }

        public void Update(GetProjectsDto entity)
        {
            var project = _unitofwork.Project.AddProject(entity);
            _unitofwork.Project.Update(project);
            _unitofwork.Save();
        }

        public void Delete(Project entity)
        {
            _unitofwork.Project.Delete(entity);
            _unitofwork.Save();
        }
        

        public List<GetProjectsDto> GetProjectsDetails()
        {
            var projects = _unitofwork.Project.GetProjectsDetails();
            return projects;
        }

        public Task<Project> DeleteProject(int id)
        {
            return _unitofwork.Project.DeleteProject(id);
        }

    }
}
