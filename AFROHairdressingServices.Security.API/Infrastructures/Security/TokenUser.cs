using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairDressingServices.Api.Models.Client.Data;

namespace AFROHairdressingServices.Security.API.Infrastructures.Security
{
    public class TokenUser
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public DateTime BirthDate { get; set; }
        public int IdProfessionnalCategory { get; set; }
        public bool Status { get; set; }
    }
}
