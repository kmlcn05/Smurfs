using Smurfs.Core.Abstract;
using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entity.Concrete
{
    public class ProjectParameters: IEntity
    {
        public int Id { get; set; }
        public DateTime ParametersDate { get; set; }
        public int ProjeCarpani { get; set; }
    }
}
