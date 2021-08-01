using HairdressingServices.Api.Models.Global.Data;
using HairdressingServices.Api.Models.Global.Mappers;
using HairdressingServices.Api.Models.Global.Repositories;
using HairdressingServices.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.Api.Models.Global.Services
{
    public class UserService : IAuthRepository
    {
        private readonly Connection _connection;
        public UserService(Connection connection)
        {
            _connection = connection;
        }

        public bool PseudoExists(string pseudo)
        {
            Command command = new("HDP_PseudoExists", true);
            command.AddParameter("Pseudo", pseudo);

            int count = (int)_connection.ExecuteScalar(command);

            return count == 1;
        }

        public bool EmailExists(string email)
        {
            Command command = new("HDP_EmailExists", true);
            command.AddParameter("Email", email);

            int count = (int)_connection.ExecuteScalar(command);

            return count == 1;
        }

        public User Get(int Id)
        {
            Command command = new("HDP_GetUser", true);
            command.AddParameter("Id", Id);

            return _connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();
        }

        public IEnumerable<User> GetAllUser()
        {
            Command command = new("Select * FROM HDR_GetAllUser", false);

            return _connection.ExecuteReader(command, dr => dr.ToUser());
        }

        public IEnumerable<User> GetAllProfessionnalUsersOrMemberUsers(int role)
        {
            Command command = new Command("HDP_GetAllProfessionnalUsersOrMemberUsers", true);
            command.AddParameter("Role", role);

            return _connection.ExecuteReader(command, dr => dr.ToUser());
        }

        public User GetUserByEmail(string email)
        {
            Command command = new("HDP_EmailExists", true);
            command.AddParameter("Email", email);

            return _connection.ExecuteReader(command, dr => dr.ToUser()).FirstOrDefault();
        }

        public User GetUserByFirstnameAndLastName(string firstname, string lastname)
        {
            Command command = new("HDP_GetUserByFirstnameAndLastname", true);
            command.AddParameter("Firstname", firstname);
            command.AddParameter("Lastname", lastname);

            return _connection.ExecuteReader(command, dr => dr.ToUser()).FirstOrDefault();
        }

        public User GetUserByPseudo(string pseudo)
        {
            Command command = new("HDP_PseudoExists", true);
            command.AddParameter("Pseudo", pseudo);

            return _connection.ExecuteReader(command, dr => dr.ToUser()).FirstOrDefault();
        }

        public User Login(string Email, string passwd)
        {
            Command command = new("HDP_AuthUser", true);
            command.AddParameter("Email", Email);
            command.AddParameter("Passwd", passwd);

            return _connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();
        }



        public void Register(User user)
        {
            Command command = new("HDP_RegisterUser", true);
            command.AddParameter("Lastname", user.Lastname);
            command.AddParameter("Firstname", user.Firstname);
            command.AddParameter("Pseudo", user.Pseudo);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Passwd", user.Passwd);
            command.AddParameter("BirthDate", user.BirthDate);
            command.AddParameter("Role", user.Role);
            command.AddParameter("Status", user.Status);

            _connection.ExecuteNonQuery(command);
            user.Passwd = null;

        }

        public bool Update(int id, User user)
        {
            Command command = new("HDP_UpdateUser", true);
            command.AddParameter("Lastname", user.Lastname);
            command.AddParameter("Firstname", user.Firstname);
            command.AddParameter("Pseudo", user.Pseudo);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Passwd", user.Passwd);
            command.AddParameter("BirthDate", user.BirthDate);
            command.AddParameter("Status", user.Status);

            int result =_connection.ExecuteNonQuery(command);
            user.Passwd = null;

            return result == 1;
        }

        public void Delete(int id)
        {
            Command command = new("HDP_LockUser", true);
            command.AddParameter("Id", id);

            _connection.ExecuteNonQuery(command);
        }

        public void ActiveUser(int id)
        {
            Command command = new("HDP_UnLockUser", true);
            command.AddParameter("Id", id);

            _connection.ExecuteNonQuery(command);
        }

        public IEnumerable<ProfessionnalCategory> AllProfessionnalCategoryOfUser(int id)
        {
            Command command = new("HDP_AllCategoryProfessionnalByUser", true);
            command.AddParameter("Id", id);

            return _connection.ExecuteReader(command, dr => dr.ToProfessionnalCategory());
        }

        public IEnumerable<Avis> GetAllAvisByProfessionnal(int Id)
        {
            Command command = new Command("HDP_GetAllAvisByProfessionnalUser", true);
            command.AddParameter("ProfessionnalId", Id);

            return _connection.ExecuteReader(command, dr => dr.ToAvis());
        }

        public int AverageStarsAvisByProfessionnal(int Id)
        {
            Command command = new Command("HDP_AverageStarsByProfessionnal", true);
            command.AddParameter("Id", Id);

            return (int)_connection.ExecuteScalar(command);
        }

        public int CountAvisByProfessionnal(int Id)
        {
            Command command = new Command("HDP_CountAvisByProfessionnal", true);
            command.AddParameter("Id", Id);

            return (int)_connection.ExecuteScalar(command);
        }
    }
}
