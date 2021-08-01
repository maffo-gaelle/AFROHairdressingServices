using HairdressingServices.Api.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.Api.Models.Global.Mappers
{
    public static class DataRecord
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataRecord"></param>
        /// <returns></returns>
        internal static ProfessionnalCategory ToProfessionnalCategory(this IDataRecord dataRecord)
        {
            return new ProfessionnalCategory()
            {
                Id = (int)dataRecord["Id"],
                NameCategory = (string)dataRecord["NameCategory"]
            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataRecord"></param>
        /// <returns></returns>
        internal static User ToUser(this IDataRecord dataRecord )
        {
            return new User()
            {
                Id = (int)dataRecord["Id"],
                Lastname = (string)dataRecord["Lastname"],
                Firstname = (string)dataRecord["Firstname"],
                Pseudo = (string)dataRecord["Pseudo"],
                Email = (string)dataRecord["Email"],
                //On ne renvoie jamais un mot de passe d'une base de données
                Passwd = null,
                Role = (int)dataRecord["Role"],
                BirthDate = (DateTime)dataRecord["BirthDate"],
                Status = (bool)dataRecord["Status"]
            };
        }

        public static UserCategoryProfessionnal ToUserCategoryProfessionnal(this IDataRecord dataRecord)
        {
            return new UserCategoryProfessionnal()
            {
                IdUser = (int)dataRecord["IdUser"],
                IdProfessionnalCategory = (int)dataRecord["IdProfessionnalCategory"]
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataRecord"></param>
        /// <returns></returns>
        internal static Avis ToAvis (this IDataRecord dataRecord)
        {
            return new Avis()
            {
                Id = (int)dataRecord["Id"],
                Content = (string)dataRecord["Content"],
                Star = (int)dataRecord["Star"],
                UserIdProfessionnal = (int)dataRecord["UserIdProfessionnal"],
                UserIdMember = (int)dataRecord["UserIdMember"],
                Timestamp = (DateTime)dataRecord["Timestamp"]

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataRecord"></param>
        /// <returns></returns>
        internal static Comment ToComment(this IDataRecord dataRecord)
        {
            return new Comment()
            {
                Id = (int)dataRecord["Id"],
                Content = (string)dataRecord["Content"],
                IdAvis = (int)dataRecord["IdAvis"],
                UserId = (int)dataRecord["UserId"]

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataRecord"></param>
        /// <returns></returns>
        internal static Image ToImage(this IDataRecord dataRecord)
        {
            return new Image()
            {
                Id = (int)dataRecord["Id"],
                PicturePath = (string)dataRecord["PicturePath"],
                UserId = (int)dataRecord["UserId"]
            };
        }
    }
}
