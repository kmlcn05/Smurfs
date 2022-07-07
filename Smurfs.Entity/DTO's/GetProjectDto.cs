using Smurfs.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entity.DTO_s
{
    public class GetProjectsDto : IDto
    {
        public int id { get; set; }
        public DateTime projectDate { get; set; }
        public string bank { get; set; }
        public string jiraProjectNo { get; set; }
        public string jiraTaskNo { get; set; }
        public string jiraProjectName { get; set; }
        public string dZDStatus { get; set; }
        public string status { get; set; }
        public string department { get; set; }
        public string team { get; set; }
        public string developer { get; set; }
        public string analyst { get; set; }
        public string totalManDay { get; set; }
        public string developerManDay { get; set; }
        public string analystManDay { get; set; }
        public string pmManDay { get; set; }
        public string IsState { get; set; }
    }
}