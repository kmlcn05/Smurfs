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
                         select new ProjectParametersDto
                         { Id = p.Id,ParametersDate = p.ParametersDate, ProjeCarpani = Convert.ToString(p.ProjeCarpani)};
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
            result.ParametersDate = projectParameters.ParametersDate;
            result.ProjeCarpani = Convert.ToInt32(projectParameters.ProjeCarpani);
            return result;
        }
    }
}