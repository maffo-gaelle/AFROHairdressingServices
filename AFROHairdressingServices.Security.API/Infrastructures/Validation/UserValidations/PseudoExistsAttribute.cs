using HairDressingServices.Api.Models.Client.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.Security.API.Infrastructures.Validation.UserValidations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PseudoExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IAuthRepository authRepository = (IAuthRepository)validationContext.GetService(typeof(IAuthRepository));

            string pseudo = value as string;

            if (!string.IsNullOrWhiteSpace(pseudo))
            {
                if (authRepository.PseudoExists(pseudo))
                {
                    return new ValidationResult("Ce pseudo existe déjà");
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
