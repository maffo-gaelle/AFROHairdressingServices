using HairdressingServices.MVC.Client.Repositories;
using GR = HairdressingServices.MVC.Global.Repositories;
using HairdressingServices.MVC.Client.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HairdressingServices.MVC.Client.Data;

namespace HairdressingServices.MVC.Client.Services
{
    public class UserCategoryProfessionnalService : IUserCategoryProfessionnalRepository
    {
        public readonly GR.IUserCategoryProfessionnalRepository _userCategoryProfessionnalRepository;

        public UserCategoryProfessionnalService(GR.IUserCategoryProfessionnalRepository userCategoryProfessionnalRepository)
        {
            _userCategoryProfessionnalRepository = userCategoryProfessionnalRepository;
        }

        public void Add(UserCategoryProfessionnal userCategoryProfessionnal)
        {
            _userCategoryProfessionnalRepository.Add(userCategoryProfessionnal.ToGlobal());
        }

        public void delete(int userId, int id)
        {
            _userCategoryProfessionnalRepository.delete(userId, id);
        }

        public ProfessionnalCategory GetProfessionnalCategoryNameById(int IdProfessionnalCategory)
        {
            return _userCategoryProfessionnalRepository.GetProfessionnalCategoryNameById(IdProfessionnalCategory).ToClient();
        }

        public IEnumerable<User> GetUsersByProfessionnalCategory(int IdProfessionnalCategory)
        {
            return _userCategoryProfessionnalRepository.GetUsersByProfessionnalCategory(IdProfessionnalCategory).Select(u => u.ToClient());
        }
    }
}
