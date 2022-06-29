using Smurfs.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entity.DTO_s
{
    public class GetCallDto: IDto
    {
        public int Id { get; set; }
        public string Bank { get; set; }
        public string TaskType { get; set; }
        public string JiraTaskNo { get; set; }
        public string CallName { get; set; }
        public string CagriCozumSuresi { get; set; }
        public string CallDetails { get; set; }
        public string CallPriority { get; set; }
        public DateTime CallDateCreated { get; set; }
        public DateTime CallDateResolved { get; set; }
        public string CallStatus { get; set; }
        public string Appointee { get; set; }
        public string Reporter { get; set; }
    }
}
