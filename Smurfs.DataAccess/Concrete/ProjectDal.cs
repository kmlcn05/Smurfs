using Microsoft.EntityFrameworkCore;
using Smurfs.Core.Abstract;
using Smurfs.Core.Concrete;
using Smurfs.DataAccess.Abstract;
using Smurfs.DataAccess.Concrete.Context;
using Smurfs.Entities.Conrete;

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
        
        
    }


}