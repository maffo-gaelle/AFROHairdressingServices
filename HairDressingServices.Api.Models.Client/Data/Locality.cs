using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDressingServices.Api.Models.Client.Data
{
    public class Locality
    {
        public string CodePostal { get; set; }
        public string Ville { get; set; }

        public Locality(string codePostal, string ville)
        {
            CodePostal = codePostal;
            Ville = ville;
        }
    }
}
