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
    public class CommentService : ICommentRepository
    {
        private readonly Connection _connection;
        public CommentService(Connection connection)
        {
            _connection = connection;
        }

        public Comment Get(int id)
        {
            Command command = new Command("SELECT * Comment WHERE Id = @Id", false);
            command.AddParameter("Id", id);

            return _connection.ExecuteReader(command, dr => dr.ToComment()).SingleOrDefault();
        }

        public void Insert(Comment comment)
        {
            Command command = new Command("HDP_AddComment", true);
            command.AddParameter("Content", comment.Content);
            command.AddParameter("@AvisId", comment.IdAvis);
            command.AddParameter("@UserId", comment.UserId);


            _connection.ExecuteNonQuery(command);
        }

        public void Update(int id, Comment comment)
        {
            Command command = new Command("HDP_UpdateComment", true);
            command.AddParameter("Id", id);
            command.AddParameter("Content", comment.Content);

            _connection.ExecuteNonQuery(command);

        }

        public void Delete(int userId, int id)
        {
            Command command = new Command("HDP_RemoveComment", true);
            command.AddParameter("Id", id);

            _connection.ExecuteNonQuery(command);
        }

        public IEnumerable<Comment> GetCommentByAvis(int AvisId)
        {
            Command command = new Command("HDP_GetAllCommentsByAvis", true);
            command.AddParameter("AvisId", AvisId);

            return _connection.ExecuteReader(command, dr => dr.ToComment());
        }

        public User GetUserComment(Comment comment)
        {
            Command command = new Command("HDP_UserByCommentId", true);
            command.AddParameter("Id", comment.UserId);

            return _connection.ExecuteReader(command, dr => dr.ToUser()).FirstOrDefault();
        }
        



    }
}
