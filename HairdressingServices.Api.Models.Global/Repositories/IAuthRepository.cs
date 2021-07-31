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
        IEnumerable<User> GetAllUser();
        IEnumerable<User> GetAllUserType(int role);
        IEnumerable<User> GetUserByProfessionnalCategory(int categoryId);
        bool Update(int id, User user);
        void Delete(int id);

    }
}
