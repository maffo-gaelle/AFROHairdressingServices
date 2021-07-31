using HairdressingServices.Api.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.Api.Models.Global.Repositories
{
    public interface ICommentRepository
    {
        Comment Get(int id);
        IEnumerable<Comment> GetCommentByAvis(int AvisId);
        void Insert(Comment comment);
        void Update(int id, Comment comment);
        void Delete(int userId, int id);


    }
}
