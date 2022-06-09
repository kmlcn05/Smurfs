using Smurfs.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entities.Conrete
{
    public class DZDStatus : IEntity
    {
        public int Id { get; set; }
        public string DZDStatusName { get; set; }

        public List<Project> Project { get; set; }
    }
}
