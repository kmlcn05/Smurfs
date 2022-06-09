using Smurfs.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entities.Conrete
{
    public class UserGroup : IEntity
    {
        public int Id { get; set; }
        public string GroupName { get; set; }

        public List<User> Users { get; set; }
    }
}
