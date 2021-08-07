using HairDressingServices.Api.Models.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.Security.API.Models.Forms.UserForm
{
    public class UpdateUserForm
    {
        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }
        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(50)]
        public string Pseudo { get; set; }
        [Required]
        [MaxLength(75)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-=]).{8,20}$")]
        public string Passwd { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public Role Role { get; set; }
        public string Description { get; set; }
    }
}
