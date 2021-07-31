using HairdressingServices.Api.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.Api.Models.Global.Repositories
{
    public interface IAuthRepository
    {
        User Login(string emailOrPseudo, string passwd);
        void Register(User user);
        bool EmailExists(string email);
        bool PseudoExists(string pseudo);
        User Get(int Id);
        User GetUserByPseudo(string pseudo);
        User GetUserByEmail(string email);
        User GetUserByFirstnameAndLastName(string firstname, string lastname);
        IEnumerable<ProfessionnalCategory> AllProfessionnalCategoryOfUser(int Id);
        IEnumerable<User> GetAllUser();
        IEnumerable<User> GetAllProfessionnalUsersOrMemberUsers(int role);
        bool Update(int id, User user);
        void Delete(int id);
        void ActiveUser(int id);
        int AverageStarsAvisByProfessionnal(int professionnalId);
        int CountAvisByProfessionnal(int professionnalId);
        IEnumerable<Avis> GetAllAvisByProfessionnal(int professionnalId);

    }
}
