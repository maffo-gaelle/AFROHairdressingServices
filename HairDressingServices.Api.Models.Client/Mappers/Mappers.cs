﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HairDressingServices.Api.Models.Client.Data;
using GR = HairdressingServices.Api.Models.Global.Data;

namespace HairDressingServices.Api.Models.Client.Mappers
{
    internal static class Mappers
    {
        internal static GR.User ToGlobal(this User entity)
        {
            return new GR.User()
            {
                Id = entity.Id,
                Lastname = entity.Lastname,
                Firstname = entity.Firstname,
                Pseudo = entity.Pseudo,
                Email = entity.Email,
                Passwd = entity.Passwd,
                Role = (int)entity.Role,
                BirthDate = entity.BirthDate,
                Status = entity.Status
            };
        }

        internal static User ToClient(this GR.User entity)
        {
            return new User(
                entity.Id,
                entity.Lastname,
                entity.Firstname,
                entity.Pseudo,
                entity.Email,
                (Role)entity.Role,
                entity.BirthDate,
                entity.Status
            );
        }

        internal static GR.ProfessionnalCategory ToGlobal(this ProfessionnalCategory entity)
        {
            return new GR.ProfessionnalCategory()
            {
                Id = entity.Id,
                NameCategory = entity.NameCategory
            };
        }

        internal static ProfessionnalCategory ToClient(this GR.ProfessionnalCategory entity)
        {
            return new ProfessionnalCategory(entity.Id, entity.NameCategory);
        }

        internal static GR.Avis ToGlobal(this Avis entity)
        {
            return new GR.Avis()
            {
                Content = entity.Content,
                Star = entity.Star,
                Timestamp = entity.Timestamp,
                UserIdMember = entity.UserIdMember,
                UserIdProfessionnal = entity.UserIdProfessionnal
            };
        }

        internal static Avis ToClient(this GR.Avis entity)
        {
            return new Avis(entity.Id, entity.Content, entity.Star, entity.UserIdProfessionnal, entity.UserIdMember, entity.Timestamp);
        }

        internal static GR.Comment ToGloblal(this Comment entity)
        {
            return new GR.Comment()
            {
                Content = entity.Content,
                Timestamp = entity.Timestamp,
                IdAvis = entity.IdAvis,
                UserId = entity.UserId
            };
        }

        internal static Comment ToClient(this GR.Comment entity)
        {
            return new Comment(entity.Id, entity.Content, entity.IdAvis, entity.UserId, entity.Timestamp);
        }

        internal static GR.UserCategoryProfessionnal ToGlobal(this UserCategoryProfessionnal entity)
        {
            return new GR.UserCategoryProfessionnal()
            {
                IdProfessionnalCategory = entity.IdProfessionnalCategory,
                IdUser = entity.IdUser
            };
        }

        internal static UserCategoryProfessionnal ToClient(this GR.UserCategoryProfessionnal entity)
        {
            return new UserCategoryProfessionnal(entity.IdUser, entity.IdProfessionnalCategory);
        }
    }
}