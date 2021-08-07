using AFROHairdressingServices.App.MVC.Infrastructures.Validations.UserValidations;
using HairdressingServices.MVC.Client.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.App.MVC.Models.Form.UserForm
{
    public class RegisterProfessionnalForm
    {
        [Required]
        [MaxLength(50)]
        [DisplayName("Nom : ")]
        public string Lastname { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Prénom : ")]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Pseudonyme : ")]
        [PseudoExists]
        public string Pseudo { get; set; }
        [Required]
        [MaxLength(75)]
        [EmailExists]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("Mot de passe : ")]
        [DataType(DataType.Password)]
        public string Passwd { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Passwd))]
        [Required]
        [DisplayName("Confirmez votre mot de passe : ")]
        public string Confirm { get; set; }
        [Required]
        public Role Role { get; set; } = Role.Professionnal;
        [Required]
        [AgeMinimum]
        [DisplayName("Date de Naissance : ")]
        public DateTime? BirthDate { get; set; }
        //[Required]
        //[ProfessionnalCategories]
        //[DisplayName("Catégorie(s) professionnelle(s) : ")]
        //public List<ProfessionnalCategory> ProfessionnalCategories { get; set; } = new List<ProfessionnalCategory>();
        [Required]
        public string Description { get; set; }

        public IEnumerable<SelectListItem> PersonnalCategories { get; set; }
        public IEnumerable<SelectListItem> Localities { get; set; }

    }
}
