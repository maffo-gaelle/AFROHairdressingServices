using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDressingServices.Api.Models.Client.Data
{
    public class UserLocality
    {
        public string CodePostal { get; set; }
        public int UserId { get; set; }

        public UserLocality(string codePostal, int userId)
        {
            CodePostal = codePostal;
            UserId = userId;
        }
    }
}
