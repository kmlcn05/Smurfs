using Smurfs.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entity.DTO_s
{
    public class CallParametersDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ParametersDate { get; set; }
        public string Call { get; set; }
        public string CallCarpani { get; set; }

        public string CallKapasite { get; set; }

        public string CallGerceklesen { get; set; }

        public string CallVerimYuzdesi { get; set; }

        public string CallVerimDegeri { get; set; }

        public string CallVerimSonucu { get; set; }
    }
}