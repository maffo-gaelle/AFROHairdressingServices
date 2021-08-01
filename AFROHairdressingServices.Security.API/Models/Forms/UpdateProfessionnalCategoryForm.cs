using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.Security.API.Models.Forms
{
    public class UpdateProfessionnalCategoryForm
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string NameCategory { get; set; }
    }
}
