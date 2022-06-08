using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entities.Conrete
{
    public class Premium
    {
        public int Id { get; set; }
        public User Users { get; set; }
        public decimal Amount { get; set; }

    }
}
