using HairdressingServices.Api.Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.Security.API.Infrastructures.Validation.UserValidations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AgeMinimumAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IAuthRepository authRepository = (IAuthRepository)validationContext.GetService(typeof(IAuthRepository));

            DateTime? birthDate = value as DateTime?;

            if (birthDate.HasValue )
            {
                var today = DateTime.Today;
                var age = today.Year - birthDate.Value.Year;
                if (today.Month > birthDate.Value.Month)
                    age++;
                if (age < 18)
                    return new ValidationResult("Vous devez avoir au moins 18 ans pour vous inscrire !");
            }
            else
            {
                return new ValidationResult($"Valeur Invalide : {validationContext.MemberName}");
            }

            return ValidationResult.Success;
        }

    }
}
