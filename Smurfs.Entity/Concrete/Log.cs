using Smurfs.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entities.Conrete
{
    public class Log : IEntity
    {
        public int Id { get; set; }
        public DateTime LogDate { get; set; }
        public User Users { get; set; }
        public string Page { get; set; }
        public Process Process { get; set; }
        public Project Projects { get; set; }
        public Call Calls { get; set; }
    }
}
