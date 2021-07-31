using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.Api.Models.Global.Data
{
    public class Image
    {
        public int Id { get; set; }
        public string PicturePath { get; set; }
        public int UserId { get; set; }
    }
}
