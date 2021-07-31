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
            Command command = new Command("HDP_PseudoExists", true);
            command.AddParameter("Pseudo", pseudo);

            int count = (int)_connection.ExecuteScalar(command);

            return count == 1;
        }

        public bool EmailExists(string email)
        {
            Command command = new Command("HDP_EmailExists", true);
            command.AddParameter("Email", email);

            int count = (int)_connection.ExecuteScalar(command);

            return count == 1;
        }

        public User Get(int Id)
        {
            Command command = new Command("HDP_GetUser", true);
            command.AddParameter("Id", Id);

            return _connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();
        }

        public IEnumerable<User> GetAllUser()
        {
            Command command = new Command("Select * FROM HDR_GetAllUser", false);

            return _connection.ExecuteReader(command, dr => dr.ToUser());
        }

        public IEnumerable<User> GetAllUserType(int role)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserByFirstnameAndLastName(string firstname, string lastname)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUserByProfessionnalCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public User GetUserByPseudo(string pseudo)
        {
            throw new NotImplementedException();
        }

        public User Login(string emailOrPseudo, string passwd)
        {
            Command command = new Command("HDP_AuthUser", true);
            command.AddParameter("EmailOrPseudo", emailOrPseudo);
            command.AddParameter("Passwd", passwd);

            return _connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();
        }



        public void Register(User user)
        {
            Command command = new Command("HDP_RegisterUser", true);
            command.AddParameter("Lastname", user.Lastname);
            command.AddParameter("Firstname", user.Firstname);
            command.AddParameter("Pseudo", user.Pseudo);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Passwd", user.Passwd);
            command.AddParameter("BirthDate", user.BirthDate);
            command.AddParameter("Role", user.Role);
            command.AddParameter("IdProfessionnalCategory", user.IdProfessionnalCategory);
            command.AddParameter("Status", user.Status);

            _connection.ExecuteNonQuery(command);
            user.Passwd = null;

        }

        public bool Update(int id, User user)
        {
            Command command = new Command("HDP_UpdateUser", true);
            command.AddParameter("Lastname", user.Lastname);
            command.AddParameter("Firstname", user.Firstname);
            command.AddParameter("Pseudo", user.Pseudo);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Passwd", user.Passwd);
            command.AddParameter("BirthDate", user.BirthDate);
            command.AddParameter("IdProfessionnalCategory", user.IdProfessionnalCategory);
            command.AddParameter("Status", user.Status);

            int result =_connection.ExecuteNonQuery(command);
            user.Passwd = null;

            return result == 1;
        }

        public void Delete(int id)
        {
            Command command = new Command("HDP_LockUser", true);
            command.AddParameter("Id", id);

            _connection.ExecuteNonQuery(command);
        }

    }
}
