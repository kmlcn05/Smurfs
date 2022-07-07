﻿using Smurfs.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entities.Conrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public byte Active { get; set; }
        public byte FirstLogin { get; set; }
        public DateTime DateOfStart { get; set; }
        public UserGroup usergroup { get; set; }
        public Team team { get; set; }
        public List<Premium> Premium { get; set; }
        public List<Log> Logs { get; set; }

    }
}
