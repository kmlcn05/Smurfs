using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public byte Active { get; set; }
        public DateTime DateOfStart { get; set; }
        //public ICollection<UserGroup> usergroup { get; set; }
        public UserGroup usergroup { get; set; }
        public Team team { get; set; }
        public Premium premium { get; set; }
        public Log log { get; set; }


    }
}
