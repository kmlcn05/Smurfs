using Smurfs.Business.Abstract;
using Smurfs.Core.Abstract;
using Smurfs.Entity.Concrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Concrete
{
    public class ProjectParametersManager : IProjectParametersService
    {
        private readonly IUnitOfWork _unitofwork;
        public ProjectParametersManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public async Task<List<ProjectParameters>> GetAllParameters()
        {
            return await _unitofwork.ProjectParameters.GetAll();

        }
        public async Task<ProjectParameters> GetByIdParameters(int id)
        {
            return await _unitofwork.ProjectParameters.GetById(id);
        }
        public void CreateParameters(ProjectParametersDto entity)
        {
            var ProjectParameters = _unitofwork.ProjectParameters.AddProjectParameters(entity);
            _unitofwork.ProjectParameters.Create(ProjectParameters);
            _unitofwork.Save();
        }
        public void UpdateParameters(ProjectParametersDto entity)
        {
            var ProjectParameters = _unitofwork.ProjectParameters.AddProjectParameters(entity);
            _unitofwork.ProjectParameters.Update(ProjectParameters);
            _unitofwork.Save();
        }
        public void DeleteParameters(ProjectParameters entity)
        {
            _unitofwork.ProjectParameters.Delete(entity);
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

        public List<ProjectParametersDto> ProjectParametersDetails()
        {
            var ProjectParameters = _unitofwork.ProjectParameters.ProjectParametersDetails();
            return ProjectParameters;
        }

        public Task<ProjectParameters> DeleteProjectParameters(int id)
        {
            return _unitofwork.ProjectParameters.DeleteProjectParameters(id);
        }
    }
}
