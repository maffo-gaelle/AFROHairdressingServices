using AFROHairdressingServices.App.MVC.Infrastructures.Validations.UserValidations;
using HairdressingServices.MVC.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.App.MVC.Models.Form.UserForm
{
    public class RegisterMemberForm
    {
        [MaxLength(50)]
        public string Lastname { get; set; }
        [MaxLength(50)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(50)]
        [PseudoExists]
        public string Pseudo { get; set; }
        [Required]
        [MaxLength(75)]
        [EmailExists]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Passwd { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Passwd))]
        [Required]
        [DisplayName("Confirmez votre mot de passe : ")]
        public string Confirm { get; set; }
        [Required]
        public Role Role { get; set; } = Role.Member;
        public DateTime? BirthDate { get; set; }
        public string Description { get; set; }
    }
}
