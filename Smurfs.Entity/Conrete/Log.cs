using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entities.Conrete
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Log_date { get; set; }
        public User Users { get; set; }
        public string Page { get; set; }
        public Process process { get; set; }
        public List<Project> Project { get; set; }
    }
}
