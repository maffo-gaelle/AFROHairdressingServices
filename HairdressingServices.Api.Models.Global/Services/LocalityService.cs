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
    public class LocalityService : ILocalityRepository
    {
        private readonly Connection _connection;
        public LocalityService(Connection connection)
        {
            _connection = connection;
        }
        public void Add(Locality locality)
        {
            Command command = new Command("HDP_AddLocality", true);
            command.AddParameter("CodePostal", locality.CodePostal);
            command.AddParameter("Ville", locality.Ville);

            _connection.ExecuteNonQuery(command);
        }

        public void Delete(string codePostal)
        {
            Command command = new Command("HDP_DeleteLocality", true);
            command.AddParameter("CodePostal", codePostal);

            _connection.ExecuteNonQuery(command);
        }

        public bool ExistsLocality(Locality locality)
        {
            Command command = new Command("HDP_LocalityExists", true);
            command.AddParameter("CodePostal", locality.CodePostal);
            command.AddParameter("Ville", locality.Ville);

            return (int)_connection.ExecuteScalar(command) == 1;
        }

        public Locality Get(string codePostal)
        {
            Command command = new Command("HDP_GetLocality", true);
            command.AddParameter("CodePostal", codePostal);

            return _connection.ExecuteReader(command, dr => dr.ToLocality()).SingleOrDefault();
        }

        public IEnumerable<Locality> Get()
        {
            Command command = new Command("HDP_GetAllLocalities", true);

            return _connection.ExecuteReader(command, dr => dr.ToLocality()); ;
        }

        public void Update(Locality locality)
        {
            Command command = new Command("HDP_UpdateLocality", true);
            command.AddParameter("CodePostal", locality.CodePostal);
            command.AddParameter("Ville", locality.Ville);

            _connection.ExecuteNonQuery(command);
        }
    }
}
