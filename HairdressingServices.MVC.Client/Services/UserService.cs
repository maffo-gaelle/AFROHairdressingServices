using HairdressingServices.MVC.Client.Data;
using HairdressingServices.MVC.Client.Repositories;
using GR = HairdressingServices.MVC.Global.Repositories;
using G = HairdressingServices.MVC.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HairdressingServices.MVC.Client.Mappers;

namespace HairdressingServices.MVC.Client.Services
{
    public class UserService : IAuthRepository
    {
        public readonly GR.IAuthRepository _authRepository;

        public UserService(GR.IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public void ActiveUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProfessionnalCategory> AllProfessionnalCategoryOfUser(int Id)
        {
            return _authRepository.AllProfessionnalCategoryOfUser(Id).Select(pc => pc.ToClient());
        }

        public int AverageStarsAvisByProfessionnal(int professionnalId)
        {
            return _authRepository.AverageStarsAvisByProfessionnal(professionnalId);
        }

        public int CountAvisByProfessionnal(int professionnalId)
        {
            return _authRepository.CountAvisByProfessionnal(professionnalId);
        }

        public void Delete(int id)
        {
            _authRepository.Delete(id);
        }

        public bool EmailExists(string email)
        {
            return _authRepository.EmailExists(email);
        }

        public User Get(int Id)
        {
            return _authRepository.Get(Id).ToClient();
        }

        public IEnumerable<Avis> GetAllAvisByProfessionnal(int professionnalId)
        {
            return _authRepository.GetAllAvisByProfessionnal(professionnalId).Select(a => a.ToClient());
        }

        public IEnumerable<User> GetAllProfessionnalUsersOrMemberUsers(int role)
        {
            return _authRepository.GetAllProfessionnalUsersOrMemberUsers(role).Select(u => u.ToClient());
        }

        public IEnumerable<User> GetAllUser()
        {
            return _authRepository.GetAllUser().Select(u => u.ToClient());
        }

        public User GetUserByEmail(string email)
        {
            return _authRepository.GetUserByEmail(email).ToClient();
        }

        public User GetUserByFirstnameAndLastName(string firstname, string lastname)
        {
            return _authRepository.GetUserByFirstnameAndLastName(firstname, lastname).ToClient();
        }

        public User GetUserByPseudo(string pseudo)
        {
            return _authRepository.GetUserByPseudo(pseudo).ToClient();
        }

        public User Login(string email, string passwd)
        {
            G.User user = _authRepository.Login(email, passwd);
            return user?.ToClient();
        }

        public bool PseudoExists(string pseudo)
        {
            return _authRepository.PseudoExists(pseudo);
        }

        public void Register(User user)
        {
            _authRepository.Register(user.ToGlobal());
        }

        public bool Update(int id, User user)
        {
            return _authRepository.Update(id, user.ToGlobal());
        }
    }
}
