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
        public string Name { get; set; }
        public DateTime ParametersDate { get; set; }
        public string Project { get; set; }
        public string ProjeCarpani { get; set; }

        public string ProjeKapasite { get; set; }

        public string ProjeGerceklesen { get; set; }

        public string ProjeVerimYuzdesi { get; set; }

        public string ProjeVerimDegeri { get; set; }

        public string ProjeVerimSonucu { get; set; }
    }
}