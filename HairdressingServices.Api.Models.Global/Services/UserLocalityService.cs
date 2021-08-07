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
    public class UserLocalityService : IUserLocalityRepository
    {
        private readonly Connection _connection;
        public UserLocalityService(Connection connection)
        {
            _connection = connection;
        }
        public void Add(UserLocality userLocality)
        {
            Command command = new Command("HDP_AddUserLocality", true);
            command.AddParameter("CodePostal", userLocality.CodePostal);
            command.AddParameter("UserId", userLocality.UserId);

            _connection.ExecuteNonQuery(command);
        }

        public void Delete(string codePostal, int userId)
        {
            Command command = new Command("HDP_DeleteUserLocality", true);
            command.AddParameter("CodePostal", codePostal);
            command.AddParameter("UserId", userId);

            _connection.ExecuteNonQuery(command);
        }

        public IEnumerable<Locality> GetAllLocalitiesByUser(int userId)
        {
            Command command = new Command("HDP_GetAllLocalitiesByUser", true);
            command.AddParameter("UserId", userId);

            return _connection.ExecuteReader(command, dr => dr.ToLocality());
        }
    }
}
