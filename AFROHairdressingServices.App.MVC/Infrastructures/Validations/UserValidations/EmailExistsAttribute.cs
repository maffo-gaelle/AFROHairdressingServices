using HairdressingServices.MVC.Client.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.App.MVC.Infrastructures.Validations.UserValidations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IAuthRepository authRepository = (IAuthRepository)validationContext.GetService(typeof(IAuthRepository));

            string email = value as string;

            if (!string.IsNullOrWhiteSpace(email))
            {
                if (authRepository.EmailExists(email))
                {
                    return new ValidationResult("Cet email existe déjà");
                }
            }
            else
            {
                return new ValidationResult($"Valeur Invalide : {validationContext.MemberName}");
            }

            return ValidationResult.Success;
        }
    }
}
