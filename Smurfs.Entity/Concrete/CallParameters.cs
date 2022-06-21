using Smurfs.Core.Abstract;
using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Entity.Concrete
{
    public class CallParameters: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ParametersDate { get; set; }
        public Call Call { get; set; }
        public int CallCarpani { get; set; }

        public int CallKapasite { get; set; }

        public int CallGerceklesen { get; set; }

        public int CallVerimYuzdesi { get; set; }

        public int CallVerimDegeri { get; set; }

        public int CallVerimSonucu { get; set; }
    }
}
