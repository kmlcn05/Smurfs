using Smurfs.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entities.Conrete
{
    public class Project : IEntity
    {
        public int Id { get; set; }
        public DateTime ProjectDate { get; set; }
        public Bank Bank { get; set; }
        public string JiraProjectNo { get; set; }
        public string JiraTaskNo { get; set; }
        public string JiraProjectName { get; set; }
        public DZDStatus DZDStatus { get; set; }
        public Status Status { get; set; }
        public Department Department { get; set; }
        public Team Team { get; set; }
        public string Developer { get; set; }
        public string Analyst { get; set; }
        public string TotalManDay { get; set; }
        public string DeveloperManDay { get; set; }
        public string AnalystManDay { get; set; }
        public string PmManDay { get; set; }
        public Log Log { get; set; }
    }
}
