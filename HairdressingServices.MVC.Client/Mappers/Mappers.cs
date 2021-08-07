using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HairdressingServices.MVC.Client.Data;
using G = HairdressingServices.MVC.Global.Data;

namespace HairdressingServices.MVC.Client.Mappers
{
    public static class Mappers
    {
        internal static User ToClient(this G.User entity)
        {
            return new User(
                entity.Id, 
                entity.Lastname, 
                entity.Firstname, 
                entity.Pseudo, 
                entity.Email, 
                (Role)entity.Role, 
                entity.BirthDate,
                entity.Description,
                entity.Status, 
                entity.Token
            );
        }

        internal static G.User ToGlobal(this User entity)
        {
            return new G.User()
            {
                Id = entity.Id,
                Lastname = entity.Lastname,
                Firstname = entity.Firstname,
                Pseudo = entity.Pseudo,
                Email = entity.Email,
                Passwd = entity.Passwd,
                Role = (int)entity.Role,
                BirthDate = entity.BirthDate,
                Status = entity.Status,
                Token = entity.Token
            };
        }

        internal static ProfessionnalCategory ToClient(this G.ProfessionnalCategory entity)
        {
            return new ProfessionnalCategory(entity.Id, entity.NameCategory);
        }

        internal static G.ProfessionnalCategory ToGlobal(this ProfessionnalCategory entity)
        {
            return new G.ProfessionnalCategory()
            {
                Id = entity.Id,
                NameCategory = entity.NameCategory
            };
        }

        internal static Avis ToClient(this G.Avis entity)
        {
            return new Avis(
                entity.Id,
                entity.Content,
                entity.Star,
                entity.UserId,
                entity.PrestationId,
                entity.Timestamp
            );
        }

        internal static G.Avis ToGlobal(this Avis entity)
        {
            return new G.Avis()
            {
                Id = entity.Id,
                Content = entity.Content,
                Star = entity.Star,
                UserId = entity.UserId,
                PrestationId = entity.PrestationId,
                Timestamp = entity.Timestamp
            };
        }

        internal static UserCategoryProfessionnal ToClient(this UserCategoryProfessionnal entity)
        {
            return new UserCategoryProfessionnal(entity.IdUser, entity.IdProfessionnalCategory);
        }

        internal static G.UserCategoryProfessionnal ToGlobal(this UserCategoryProfessionnal entity)
        {
            return new G.UserCategoryProfessionnal()
            {
                IdUser = entity.IdUser,
                IdProfessionnalCategory = entity.IdProfessionnalCategory
            };
        }

        internal static Comment ToClient(this G.Comment entity)
        {
            return new Comment(
                entity.Id,
                entity.Content,
                entity.IdAvis,
                entity.UserId,
                entity.Timestamp
            );
        }

        internal static G.Comment ToGlobal(this Comment entity)
        {
            return new G.Comment()
            {
                Id = entity.Id,
                Content = entity.Content,
                IdAvis = entity.IdAvis,
                UserId = entity.UserId,
                Timestamp = entity.Timestamp
            };
        }


    }
}
