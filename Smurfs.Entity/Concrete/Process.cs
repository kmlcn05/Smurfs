using Smurfs.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entities.Conrete
{
    public class Process : IEntity
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }

        public List<Log> Logs { get; set; }

    }
}
