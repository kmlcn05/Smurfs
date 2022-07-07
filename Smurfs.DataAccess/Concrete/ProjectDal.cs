using Microsoft.EntityFrameworkCore;
using Smurfs.Core.Abstract;
using Smurfs.Core.Concrete;
using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Concrete.Context;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Concrete
{

    public class ProjectDal : EfEntityRepositoryBase<Project>, IProjectDal
    {
        
        public ProjectDal(DbContext ctx) : base(ctx)
        {

        }
        private SmurfsContext SmurfsContext
        {
            get { return context as SmurfsContext; }
        }

        public List<GetProjectsDto> GetProjectsDetails()
        {

            var result = from p in SmurfsContext.Projects
                         join b in SmurfsContext.Banks
                         on p.Bank.Id equals b.Id
                         join dz in SmurfsContext.DZDStatuses
                         on p.DZDStatus.Id equals dz.Id
                         join s in SmurfsContext.Statuses
                         on p.Status.Id equals s.Id
                         join de in SmurfsContext.Departments
                         on p.Department.Id equals de.Id
                         join te in SmurfsContext.Teams
                         on p.Team.Id equals te.Id
                         select new GetProjectsDto
                         { id = p.Id, projectDate = p.ProjectDate, bank = b.BankName, jiraProjectNo = p.JiraProjectNo, jiraTaskNo = p.JiraTaskNo, jiraProjectName = p.JiraProjectName, dZDStatus = dz.DZDStatusName, status = s.StatusName, department = de.DepartmentName, team = te.TeamName, developer = p.Developer, analyst = p.Analyst, totalManDay = p.TotalManDay, developerManDay = p.DeveloperManDay, analystManDay = p.AnalystManDay, pmManDay = p.PmManDay ,IsState = Convert.ToString(p.IsState) };
            return result.ToList();
        }

        public async Task<Project> DeleteProject(int id)
        {
            var result = await SmurfsContext.Projects
                .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                SmurfsContext.Projects.Remove(result);
                await SmurfsContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public Project AddProject(GetProjectsDto project)
        {
            var result = new Project();

            result.Id = project.id;
            result.ProjectDate = project.projectDate;
            result.JiraProjectNo = project.jiraProjectNo;
            result.JiraTaskNo = project.jiraTaskNo;
            result.JiraProjectName = project.jiraProjectName;
            result.Bank = SmurfsContext.Banks.Single(a => a.BankName == project.bank);
            result.DZDStatus = SmurfsContext.DZDStatuses.Single(a => a.DZDStatusName == project.dZDStatus);
            result.Status = SmurfsContext.Statuses.Single(a => a.StatusName == project.status);
            result.Department = SmurfsContext.Departments.Single(a => a.DepartmentName == project.department);
            result.Team = SmurfsContext.Teams.Single(a => a.TeamName == project.team);
            result.Developer = project.developer;
            result.Analyst = project.analyst;
            result.TotalManDay = project.totalManDay;
            result.DeveloperManDay = project.developerManDay;
            result.AnalystManDay = project.analystManDay;
            result.PmManDay = project.pmManDay;
            result.IsState = Convert.ToBoolean(project.IsState);
            return result;
        }


    }


}