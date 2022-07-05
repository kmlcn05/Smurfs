﻿using Smurfs.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entity.DTO_s
{
    public class LogDto : IDto
    {
        public int Id { get; set; }
        public DateTime LogDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Page { get; set; }
        public string Process { get; set; }
    }
}