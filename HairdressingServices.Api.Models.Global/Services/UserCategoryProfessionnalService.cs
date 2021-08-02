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
    public class UserCategoryProfessionnalService : IUserCategoryProfessionnalRepository
    {
        private readonly Connection _connection;
        public UserCategoryProfessionnalService(Connection connection)
        {
            _connection = connection;
        }
        public void Add(UserCategoryProfessionnal userCategoryProfessionnal)
        {
            Command command = new Command("HDP_AddUserCategoryProfessionnal", true);
            command.AddParameter("UserId", userCategoryProfessionnal.IdUser);
            command.AddParameter("IdProfessionnalCategory", userCategoryProfessionnal.IdProfessionnalCategory);

            _connection.ExecuteNonQuery(command);
        }

        public void delete(int userId, int id)
        {
            Command command = new Command("HDP_DeleteUserCategoryProfessionnal", true);
            command.AddParameter("UserId", userId);
            command.AddParameter("IdProfessionnalCategory", id);

            _connection.ExecuteNonQuery(command); 
        }

        public ProfessionnalCategory GetProfessionnalCategoryNameById(int IdProfessionnalCategory)
        {
            Command command = new Command("HDP_GetProfessionnalCategoryNameById", true);
            command.AddParameter("IdProfessionnalCategory", IdProfessionnalCategory);

            return _connection.ExecuteReader(command, dr => dr.ToProfessionnalCategory()).FirstOrDefault();
        }

        public IEnumerable<User> GetUsersByProfessionnalCategory(int IdProfessionnalCategory)
        {
            Command command = new Command("HDP_GetUsersByProfessionnalCategory", true);
            command.AddParameter("IdProfessionnalCategory", IdProfessionnalCategory);

            return _connection.ExecuteReader(command, dr => dr.ToUser());
        }
    }
}
