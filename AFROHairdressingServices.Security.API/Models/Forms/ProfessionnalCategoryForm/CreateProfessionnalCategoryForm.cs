using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.Security.API.Models.Forms.ProfessionnalCategoryForm
{
    public class CreateProfessionnalCategoryForm
    {
        [Required]
        [MaxLength(50)]
        public string NameCategory { get; set; }
    }
}
