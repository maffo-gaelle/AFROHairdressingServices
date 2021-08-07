using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDressingServices.Api.Models.Client.Data
{
    public class Avis
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Star { get; set; }
        public int UserId { get; set; }
        public int PrestationId { get; set; }
        public DateTime Timestamp { get; set; }

        public Avis(string content, int star, int userId, int prestationId, DateTime timestamp)
        {
            Content = content;
            Star = star;
            UserId = userId;
            PrestationId = prestationId;
            Timestamp = timestamp;
        }

        public Avis(int id, string content, int star, int userId, int prestationId, DateTime timestamp)
            :this(content, star, userId, prestationId, timestamp)
        {
            Id = id;
        }
    }
}
