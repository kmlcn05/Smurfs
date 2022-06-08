using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entities.Conrete
{
    public class DZDStatus
    {
        public int Id { get; set; }
        public string DZDStatusName { get; set; }

        public List<Project> Project { get; set; }
    }
}
