using Smurfs.Core.Abstract;
using Smurfs.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entities.Conrete
{
    public class Call : IEntity
    {
        public int Id { get; set; }
        public Bank Bank { get; set; }
        public string JiraProjectNo { get; set; }
        public string JiraTaskNo { get; set; }
        public string JiraProjectName { get; set; }
        public string CallName { get; set; }
        public string CagriCozumSuresi { get; set; }
        public string CallDetails { get; set; }
        public string CallPriority { get; set; }
        public DateTime CallDate { get; set; }
        public CallStatus CallStatus { get; set; }
        public string Appointee { get; set; }
        public List<Log> Log { get; set; }
        public List<CallParameters> CallParameters { get; set; }
    }
}
