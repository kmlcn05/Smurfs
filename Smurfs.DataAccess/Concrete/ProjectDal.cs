using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Concrete.Context;
using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Concrete
{
    public class ProjectDal:IProjectDal
    {
        public List<Project>? GetAllProjects()
        {
            using var context = new SmurfsContext();
            return context.Projects?.ToList();
        }
        public Project? GetProjectById(long projectId)
        {
            using var context = new SmurfsContext();
            return context.Projects?.FirstOrDefault(x => x.Id == projectId); 
        }
        public void SaveProject(Project project)
        {
            using var context = new SmurfsContext();
            context.Add<Project>(project);
            context.SaveChanges();            
        }
        public void UpdateProject(Project project)
        {
            using var context = new SmurfsContext();
            context.Update<Project>(project);
            context.SaveChanges();            
        }
        public void DeleteProject(Project project)
        {
            using var context = new SmurfsContext();
            context.Remove<Project>(project);
            context.SaveChanges();            
        }
    }
}
