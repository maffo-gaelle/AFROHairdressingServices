using HairDressingServices.Api.Models.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDressingServices.Api.Models.Client.Repositories
{
    public interface IUserCategoryProfessionnalRepository
    {
        void Add(UserCategoryProfessionnal userCategoryProfessionnal);
        void delete(UserCategoryProfessionnal userCategoryProfessionnal);
        IEnumerable<User> GetUsersByProfessionnalCategory(int IdProfessionnalCategory);
        ProfessionnalCategory GetProfessionnalCategoryNameById(int IdProfessionnalCategory);
    }
}
