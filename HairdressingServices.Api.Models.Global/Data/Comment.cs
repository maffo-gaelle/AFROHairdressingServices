using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.Api.Models.Global.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int IdAvis { get; set; }
    }
}
