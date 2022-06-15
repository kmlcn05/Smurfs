using Smurfs.Business.Abstract;
using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Concrete;
using Smurfs.Entities.Conrete;

namespace Smurfs.Business.Concrete
{
    public class ProjectManager : IProjectService
    {

        private readonly IProjectDal _projectDal;
        public ProjectManager(ProjectDal projectDal)
        {
            _projectDal = projectDal;
        }
        public List<Project> GetAllProjects()
        {
            return _projectDal.GetAllProjects();

        }
        public Project GetProjectById(long projectId)
        {
            var recordedProject = _projectDal.GetProjectById(projectId);
            if (recordedProject != null)
            {
                return recordedProject;
            }
            else
            {
                throw new Exception("Project not found!");
            }

        }
        public void SaveProject(Project project)
        {
            var recordedProject = _projectDal.GetProjectById(project.Id);
            if (recordedProject == null)
            {
                _projectDal.SaveProject(project);


            }
            else
            {
                throw new Exception("Project already recorded!");
            }

        }

        public void UpdateProject(Project project)
        {
            var recordedProject = _projectDal.GetProjectById(project.Id);
            if (project != null)
            {
                _projectDal.UpdateProject(project);

            }
            else
            {
                throw new Exception("Project not found!");
            }

        }
        public void DeleteProject(long projectId)
        {
            var project = _projectDal.GetProjectById(projectId);
            if (project != null)
            {
                _projectDal.DeleteProject(project);

            }
            else
            {
                throw new Exception("Project not found!");
            }

        }
        public Project Calculate(long projectId)
        {
            var project = _projectDal.GetProjectById(projectId);
            if (project != null)
            {
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
