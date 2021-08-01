using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDressingServices.Api.Models.Client.Data
{
    public class UserCategoryProfessionnal
    {
        public int IdUser { get; set; }
        public int IdProfessionnalCategory { get; set; }

        public UserCategoryProfessionnal(int idUser, int idProfessionnalCategory)
        {
            IdUser = idUser;
            IdProfessionnalCategory = idProfessionnalCategory;
        }
    }
}
