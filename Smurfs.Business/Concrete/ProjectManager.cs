using Smurfs.Business.Abstract;
using Smurfs.Core.Abstract;
using Smurfs.Entities.Conrete;

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

        public void Create(Project entity)
        {
            _unitofwork.Project.Create(entity);
            _unitofwork.Save();
        }

        public void Update(Project entity)
        {
            _unitofwork.Project.Update(entity);
            _unitofwork.Save();
        }

        public void Delete(Project entity)
        {
            _unitofwork.Project.Delete(entity);
            _unitofwork.Save();
        }
        public Project Calculate(int projectId)
        {
            var projects = _unitofwork.Project.GetById(projectId);
            if (projects != null)
            {
                Project project = new Project();
                project.ProjeVerimYuzdesi = (project.ProjeGerceklesen / project.ProjeKapasite) * 100;
                project.ProjeVerimDegeri = (project.ProjeGerceklesen - project.ProjeKapasite);

                if (project.ProjeVerimDegeri < 0)
                {
                    project.ProjeVerimDegeri = 0;
                }
                else
                {
                    project.ProjeVerimDegeri = project.ProjeVerimDegeri;
                }
                project.ProjeVerimSonucu = (project.ProjeVerimDegeri * project.ProjeCarpani);

                Project projecthesap = new Project();
                projecthesap = project;

                return projecthesap;
            }
            else
            {
                throw new Exception("Project Not found!");
            }

        }

    }
}
