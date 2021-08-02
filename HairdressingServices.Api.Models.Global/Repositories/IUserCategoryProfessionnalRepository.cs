using HairdressingServices.Api.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.Api.Models.Global.Repositories
{
    public interface IUserCategoryProfessionnalRepository
    {
        void Add(UserCategoryProfessionnal userCategoryProfessionnal);
        void delete(int userId, int id);
        IEnumerable<User> GetUsersByProfessionnalCategory(int IdProfessionnalCategory);
        ProfessionnalCategory GetProfessionnalCategoryNameById(int IdProfessionnalCategory);
    }
}
