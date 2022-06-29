
using Smurfs.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Smurfs.Entity.DTO_s
{
    public class UserDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Active { get; set; }
        public DateTime DateOfStart { get; set; }
        //public ICollection<UserGroup> usergroup { get; set; }
        public string usergroup { get; set; }
        public string team { get; set; }
    }
}

