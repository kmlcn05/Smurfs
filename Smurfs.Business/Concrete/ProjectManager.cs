using Core.Utilities.Results;
using Smurfs.DataAccess.Concrete;
using Smurfs.Business.Abstract;
using Smurfs.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smurfs.DataAccess.Abstract;
using Smurfs.Entities.Conrete;

namespace Smurfs.Business.Concrete
{
    public class ProjectManager:IProjectService
    {

        private readonly IProjectDal _projectDal;
        public ProjectManager(ProjectDal projectDal)
        {
            _projectDal = projectDal;
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

    }
}
