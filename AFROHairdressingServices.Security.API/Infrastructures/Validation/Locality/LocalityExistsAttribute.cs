using HairDressingServices.Api.Models.Client.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.Security.API.Infrastructures.Validation.Locality
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LocalityExistsAttribute : ValidationAttribute
    {
        //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //    {
        //        ILocalityRepository localityRepository = (ILocalityRepository)validationContext.GetService(typeof(ILocalityRepository));

        //        string email = value as string;

        //        if (!string.IsNullOrWhiteSpace(email))
        //        {
        //            if (localityRepository.EmailExists(email))
        //            {
        //                return new ValidationResult("Cet email existe déjà");
        //            }
        //        }
        //        else
        //        {
        //            return new ValidationResult($"Valeur Invalide : {validationContext.MemberName}");
        //        }

        //        return ValidationResult.Success;
        //    }
    }
}
