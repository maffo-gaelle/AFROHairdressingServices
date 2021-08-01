using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDressingServices.Api.Models.Client.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int IdAvis { get; set; }
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }

        public Comment(string content, int idAvis, int userId, DateTime timestamp)
        {
            Content = content;
            IdAvis = idAvis;
            UserId = userId;
            Timestamp = timestamp;
        }

        public Comment(int id, string content, int idAvis, int userId, DateTime timestamp)
            :this(content, idAvis, userId, timestamp)
        {
            Id = id;
        }
    }
}
