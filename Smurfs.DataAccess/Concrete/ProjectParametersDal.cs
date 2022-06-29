using Microsoft.EntityFrameworkCore;
using Smurfs.Core.Concrete;
using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Concrete.Context;
using Smurfs.Entity.Concrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Concrete
{
    public class ProjectParametersDal : EfEntityRepositoryBase<ProjectParameters>, IProjectParametersDal
    {
        public ProjectParametersDal(DbContext ctx) : base(ctx)
        {

        }
        private SmurfsContext SmurfsContext
        {
            get { return context as SmurfsContext; }
        }
        public List<ProjectParametersDto> ProjectParametersDetails()
        {

            var result = from p in SmurfsContext.ProjectParameters
                         join b in SmurfsContext.Projects
                         on p.Project.Id equals b.Id
                         select new ProjectParametersDto
                         { Id = p.Id, Name = p.Name, ParametersDate = p.ParametersDate, ProjeCarpani = Convert.ToString(p.ProjeCarpani), 
                         ProjeKapasite = Convert.ToString(p.ProjeKapasite), ProjeGerceklesen = Convert.ToString(p.ProjeGerceklesen), 
                         ProjeVerimYuzdesi = Convert.ToString(p.ProjeVerimYuzdesi), ProjeVerimDegeri = Convert.ToString(p.ProjeVerimDegeri), 
                         ProjeVerimSonucu = Convert.ToString(p.ProjeVerimSonucu), Project = b.JiraProjectName };
            return result.ToList();
        }

        public async Task<ProjectParameters> DeleteProjectParameters(int id)
        {
            var result = await SmurfsContext.ProjectParameters
                .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                SmurfsContext.ProjectParameters.Remove(result);
                await SmurfsContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public ProjectParameters AddProjectParameters(ProjectParametersDto projectParameters)
        {
            var result = new ProjectParameters();

            result.Id = projectParameters.Id;
            result.Name = projectParameters.Name;
            result.ParametersDate = projectParameters.ParametersDate;
            result.ProjeCarpani = Convert.ToInt32(projectParameters.ProjeCarpani);
            result.ProjeKapasite = Convert.ToInt32(projectParameters.ProjeKapasite);
            result.ProjeGerceklesen = Convert.ToInt32(projectParameters.ProjeGerceklesen);
            result.ProjeVerimYuzdesi = Convert.ToInt32(projectParameters.ProjeVerimYuzdesi);
            result.ProjeVerimSonucu = Convert.ToInt32(projectParameters.ProjeVerimSonucu);
            result.ProjeVerimDegeri = Convert.ToInt32(projectParameters.ProjeVerimDegeri);
            result.Project = SmurfsContext.Projects.Single(a => a.JiraProjectName == projectParameters.Project);

            return result;
        }
    }
}