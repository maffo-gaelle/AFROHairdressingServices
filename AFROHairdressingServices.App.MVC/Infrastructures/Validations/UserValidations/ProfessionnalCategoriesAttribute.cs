using HairdressingServices.MVC.Client.Data;
using HairdressingServices.MVC.Client.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.App.MVC.Infrastructures.Validations.UserValidations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ProfessionnalCategoriesAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IAuthRepository authRepository = (IAuthRepository)validationContext.GetService(typeof(IAuthRepository));

            List<ProfessionnalCategory> professionnalCategories = value as List<ProfessionnalCategory>;

            if (professionnalCategories.Count == 0)
            {
                return new ValidationResult("Vous devez choisir au moins une catégorie professionnelle !");
            }

            return ValidationResult.Success;
        }

    }
}
