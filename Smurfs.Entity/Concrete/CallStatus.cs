using Smurfs.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entities.Conrete
{
    public class CallStatus : IEntity
    {
        public int Id { get; set; }
        public string CallStatusName { get; set; }
    }
}
