using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.Security.API.Models.Forms.AvisForm
{
    public class UpdateAvisForm
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Star { get; set; }
        public int UserId { get; set; }
        public int PrestationId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
