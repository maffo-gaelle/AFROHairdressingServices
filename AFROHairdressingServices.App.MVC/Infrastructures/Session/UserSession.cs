using HairdressingServices.MVC.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.App.MVC.Infrastructures.Session
{
    public class UserSession
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Status { get; set; }
        public string Token { get; set; }
    }
}
