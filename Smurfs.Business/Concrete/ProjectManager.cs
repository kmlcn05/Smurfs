using Core.Utilities.Results;
using Smurfs.DataAccess.Concrete;
using Smurfs.Business.Abstract;
using Smurfs.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Concrete
{
    public class ProjectManager:IProjectService
    {

        private readonly IProjectService _projectService;
        public ProjectManager(ProjectManager projectService)
        {
            _projectService = projectService;
        }
        public void SaveProject(ProjectModel project)
        {
            var recordedProject = _projectService.GetProjectById(project.Id);
            if (recordedProject != null)
            {
                _projectService.SaveProject(project);
            }
            else
            {
                throw new Exception("Project already recorded!");
            }

        }
        
        public void UpdateProject(ProjectModel project)
        {
            var recordedProject = _projectService.GetProjectById(project.Id);
            if (project != null)
            {
                _projectService.UpdateProject(project);
            }
            else
            {
                throw new Exception("Project not found!");
            }

        }
        public void DeleteProject(long projectId)
        {
            var project = _projectService.GetProjectById(projectId);
            if (project != null)
            {
                _projectService.DeleteProject(project);
            }
            else
            {
                throw new Exception("Project not found!");
            }

        }

    }
}
