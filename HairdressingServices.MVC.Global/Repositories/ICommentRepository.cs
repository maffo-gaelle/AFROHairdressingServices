using HairdressingServices.MVC.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.MVC.Global.Repositories
{
    public interface ICommentRepository
    {
        Comment Get(int id);
        IEnumerable<Comment> GetCommentByAvis(int AvisId);
        User GetUserComment(Comment comment);
        void Insert(Comment comment);
        void Update(int id, Comment comment);
        void Delete(int userId, int id);
    }
}
