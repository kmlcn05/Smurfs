using Smurfs.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entity.DTO_s
{
    public class ProjectParametersDto : IDto
    {
        public int Id { get; set; }
        public DateTime ParametersDate { get; set; }
        public string ProjeCarpani { get; set; }
    }
}