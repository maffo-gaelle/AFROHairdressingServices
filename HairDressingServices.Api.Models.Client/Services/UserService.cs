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
    public class UserService : IAuthRepository
    {
        //private readonly GR.IAuthRepository _globalRepository;
        private readonly GR.IAuthRepository _authRepository;

        public UserService(GR.IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public User Get(int Id)
        {
            return _authRepository.Get(Id).ToClient();
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

        public IEnumerable<User> GetAllProfessionnalUsersOrMemberUsers(int role)
        {
            return _authRepository.GetAllProfessionnalUsersOrMemberUsers(role).Select(u => u.ToClient());
        }

        public IEnumerable<User> GetAllUser()
        {
            return _authRepository.GetAllUser().Select(u => u.ToClient());
        }
        public bool EmailExists(string email)
        {
            return _authRepository.EmailExists(email);
        }

        public bool PseudoExists(string pseudo)
        {
            return _authRepository.PseudoExists(pseudo);
        }

        public User Login(string email, string passwd)
        {
            return _authRepository.Login(email, passwd)?.ToClient();
        }

        public int Register(User user)
        {
           return _authRepository.Register(user.ToGlobal());
        }


        public bool Update(int id, User user)
        {
            return _authRepository.Update(id, user.ToGlobal());
        }

        public void Delete(int id)
        {
             _authRepository.Delete(id);
        }

        public void ActiveUser(int id)
        {
            _authRepository.ActiveUser(id);
        }

        public IEnumerable<ProfessionnalCategory> AllProfessionnalCategoryOfUser(int Id)
        {
            return _authRepository.AllProfessionnalCategoryOfUser(Id).Select(pc => pc.ToClient());
        }

        public IEnumerable<Avis> GetAllAvisByProfessionnal(int professionnalId)
        {
            return _authRepository.GetAllAvisByProfessionnal(professionnalId).Select(a => a.ToClient());
        }

        public int AverageStarsAvisByProfessionnal(int professionnalId)
        {
            return _authRepository.AverageStarsAvisByProfessionnal(professionnalId);
        }

        public int CountAvisByProfessionnal(int professionnalId)
        {
            return _authRepository.CountAvisByProfessionnal(professionnalId);
        }


    }
}
