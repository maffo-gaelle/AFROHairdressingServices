using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.App.MVC.Models.Form
{
    public class LoginForm
    {
        [Required]
        [MaxLength(384)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Passwd { get; set; }
    }
}
