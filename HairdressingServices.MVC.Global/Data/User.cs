using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.MVC.Global.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public int Role { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Status { get; set; }
        public string Token { get; set; }
    }
}
