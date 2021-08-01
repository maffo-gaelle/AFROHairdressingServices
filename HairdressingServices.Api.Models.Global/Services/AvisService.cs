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
    public class AvisService : IAvisRepository
    {
        private readonly Connection _connection;
        public AvisService(Connection connection)
        {
            _connection = connection;
        }

        
        public Avis Get(int id)
        {
            Command command = new Command("HDP_GetAvis", true);
            command.AddParameter("Id", id);

            return _connection.ExecuteReader(command, dr => dr.ToAvis()).FirstOrDefault();
        }

        public IEnumerable<Avis> GetAllAvisByProfessionnal(int professionnalId)
        {
            Command command = new Command("HDP_GetAllAvisByProfessionnalUser", true);
            command.AddParameter("ProfessionnalId", professionnalId);

            return _connection.ExecuteReader(command, dr => dr.ToAvis());
        }

        public IEnumerable<Comment> GetAllCommentByAvis(int id)
        {
            Command command = new Command("HDP_GetAllCommentsByAvis", true);
            command.AddParameter("AvisId", id);

            return _connection.ExecuteReader(command, dr => dr.ToComment());

        }

        public void Insert(Avis avis)
        {
            Command command = new Command("HDP_AddAvis", true);
            command.AddParameter("Content", avis.Content);
            command.AddParameter("Star", avis.Star);
            command.AddParameter("UserIdMember", avis.UserIdMember);
            command.AddParameter("UserIdProfessionnal", avis.UserIdProfessionnal);
            command.AddParameter("Timestamp", avis.Timestamp);

            _connection.ExecuteNonQuery(command);

        }

        public void Update(int id, Avis avis)
        {
            Command command = new Command("HDP_UpdateAvis", true);
            command.AddParameter("Content", avis.Content);
            command.AddParameter("Star", avis.Star);
            command.AddParameter("Id", id);

            _connection.ExecuteNonQuery(command);
        }

    }
}
