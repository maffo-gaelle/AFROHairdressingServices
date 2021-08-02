using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.MVC.Global.Data
{
    public class Avis
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Star { get; set; }
        public int UserIdProfessionnal { get; set; }
        public int UserIdMember { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
