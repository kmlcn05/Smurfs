using Smurfs.Business.Abstract;
using Smurfs.Core.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.Concrete;

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
       public ProjectParameters Calculate(int projectId)
        {
            var project = _unitofwork.Project.GetById(projectId);
            if (project != null)
            {
                ProjectParameters projectparameter = new ProjectParameters();
                projectparameter.ProjeVerimYuzdesi = (projectparameter.ProjeGerceklesen / projectparameter.ProjeKapasite) * 100;
                projectparameter.ProjeVerimDegeri = (projectparameter.ProjeGerceklesen - projectparameter.ProjeKapasite);

                if (projectparameter.ProjeVerimDegeri < 0)
                {
                    projectparameter.ProjeVerimDegeri = 0;
                }
                else
                {
                    projectparameter.ProjeVerimDegeri = projectparameter.ProjeVerimDegeri;
                }
                projectparameter.ProjeVerimSonucu = (projectparameter.ProjeVerimDegeri * projectparameter.ProjeCarpani);

                ProjectParameters projecthesap = new ProjectParameters();
                projecthesap = projectparameter;

                return projecthesap;
            }
            else
            {
                throw new Exception("Project Not found!");
            }

        }

    }
}
