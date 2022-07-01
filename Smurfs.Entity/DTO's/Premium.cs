using Smurfs.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entity.DTO_s
{
    public class PremiumDto : IDto
    {
        public int Id { get; set; }
        //public User Users { get; set; }
        public string Amount { get; set; }
        public DateTime PremiumDate { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

    }
}