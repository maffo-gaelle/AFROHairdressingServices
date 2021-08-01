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
        public int UserIdProfessionnal { get; set; }
        public int UserIdMember { get; set; }
        public DateTime Timestamp { get; set; }

        public Avis(string content, int star, int userIdProfessionnal, int userIdMember, DateTime timestamp)
        {
            Content = content;
            Star = star;
            UserIdProfessionnal = userIdProfessionnal;
            UserIdMember = userIdMember;
            Timestamp = timestamp;
        }

        public Avis(int id, string content, int star, int userIdProfessionnal, int userIdMember, DateTime timestamp)
            :this(content, star, userIdProfessionnal, userIdMember, timestamp)
        {
            Id = id;
        }
    }
}
