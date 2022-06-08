using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entities.Conrete
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }

        public List<User> Users { get; set; }

        public List<Project> Project { get; set; }
    }
}
