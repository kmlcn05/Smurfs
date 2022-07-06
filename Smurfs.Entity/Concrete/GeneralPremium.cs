using Smurfs.Core.Abstract;
using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entity.Concrete
{
    public class GeneralPremium:IEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

        public decimal ProjectAmount { get; set; }

        public decimal CallAmount { get; set; }
        public DateTime PremiumDate { get; set; }

        public User Users { get; set; }
    }
}
