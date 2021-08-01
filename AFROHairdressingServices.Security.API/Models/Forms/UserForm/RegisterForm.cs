﻿using AFROHairdressingServices.Security.API.Infrastructures.Validation.UserValidations;
using HairDressingServices.Api.Models.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.Security.API.Models.Forms.UserForm
{
    public class RegisterForm
    {
        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }
        [Required]
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
        //[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-=]).{8,20}$")]
        public string Passwd { get; set; }
        [Required]
        public Role Role { get; set; } = Role.Member;
        public DateTime BirthDate { get; set; }



    }
}