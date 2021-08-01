using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.Security.API.Models.Forms.CommentForm
{
    public class AddCommentForm
    {
        [Required]
        [MaxLength(384)]
        public string Content { get; set; }
        [Required]
        public int AvisId { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTime Timestamp { get; set;  }
    }
}
