using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entities.Conrete
{
    public class Project
    {
        public int Id { get; set; }
        public DateTime ProjectDate { get; set; }
        public int BankId { get; set; }
        public string JiraProjectNo { get; set; }
        public string JiraTaskNo { get; set; }
        public string JiraProjectName { get; set; }
        public int DZDStatusId { get; set; }
        public int StatusId { get; set; }
        public int DepartmentId { get; set; }
        public int TeamId { get; set; }
        public string Developer { get; set; }
        public string Analyst { get; set; }
        public string TotalManDay { get; set; }
        public string DeveloperManDay { get; set; }
        public string AnalystManDay { get; set; }
        public string PmManDay { get; set; }
        public string LogId { get; set; }
    }
}
