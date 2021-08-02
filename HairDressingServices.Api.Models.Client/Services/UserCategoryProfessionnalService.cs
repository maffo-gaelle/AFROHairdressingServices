using HairDressingServices.Api.Models.Client.Data;
using HairDressingServices.Api.Models.Client.Mappers;
using HairDressingServices.Api.Models.Client.Repositories;
using GR = HairdressingServices.Api.Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDressingServices.Api.Models.Client.Services
{
    public class UserCategoryProfessionnalService : IUserCategoryProfessionnalRepository
    {
        private readonly GR.IUserCategoryProfessionnalRepository _userCategoryProfessionnal;

        public UserCategoryProfessionnalService(GR.IUserCategoryProfessionnalRepository userCategoryProfessionnal)
        {
            _userCategoryProfessionnal = userCategoryProfessionnal;
        }

        public void Add(UserCategoryProfessionnal userCategoryProfessionnal)
        {
            _userCategoryProfessionnal.Add(userCategoryProfessionnal.ToGlobal());
        }

        public void delete(int userId, int id)
        {
            _userCategoryProfessionnal.delete(userId, id);
        }

        public ProfessionnalCategory GetProfessionnalCategoryNameById(int IdProfessionnalCategory)
        {
            return _userCategoryProfessionnal.GetProfessionnalCategoryNameById(IdProfessionnalCategory).ToClient();
        }

        public IEnumerable<User> GetUsersByProfessionnalCategory(int IdProfessionnalCategory)
        {
            return _userCategoryProfessionnal.GetUsersByProfessionnalCategory(IdProfessionnalCategory).Select(u => u.ToClient());
        }
    }
}
