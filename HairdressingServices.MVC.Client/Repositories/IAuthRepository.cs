using HairdressingServices.MVC.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.MVC.Client.Repositories
{
    public interface IAuthRepository
    {
        User LoginClient(string email, string passwd);
        User LoginProfessionnal(string email, string passwd);
        User RegisterMember(User user);
        User RegisterProfessionnal(User user);
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
