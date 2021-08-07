using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.Security.API.Models.Forms
{
    public class LocalityFormcs
    {
        [Required]
        public string CodePostal { get; set; }
        [Required]
        public string Ville { get; set; }
    }
}
