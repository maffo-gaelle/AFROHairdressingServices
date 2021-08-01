using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.Security.API.Models.Forms.AvisForm
{
    public class AddAvisForm
    {
        [Required]
        [MaxLength(380)]
        public string Content { get; set; }
        [Required]
        public int Star { get; set; } = 1;
        [Required]
        public int UserIdProfessionnal { get; set; }
        [Required]
        public int UserIdMember { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
    }
}
