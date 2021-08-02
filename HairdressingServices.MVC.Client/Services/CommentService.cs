using HairdressingServices.MVC.Client.Repositories;
using GR = HairdressingServices.MVC.Global.Repositories;
using HairdressingServices.MVC.Client.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HairdressingServices.MVC.Client.Data;

namespace HairdressingServices.MVC.Client.Services
{
    public class CommentService : ICommentRepository
    {
        public readonly GR.ICommentRepository _commentRepository;

        public CommentService(GR.ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Delete(int userId, int id)
        {
            throw new NotImplementedException();
        }

        public Comment Get(int id)
        {
            return _commentRepository.Get(id).ToClient();
        }

        public IEnumerable<Comment> GetCommentByAvis(int AvisId)
        {
            return _commentRepository.GetCommentByAvis(AvisId).Select(c => c.ToClient());
        }

        public User GetUserComment(Comment comment)
        {
            return _commentRepository.GetUserComment(comment.ToGlobal()).ToClient();
        }

        public void Insert(Comment comment)
        {
            _commentRepository.Insert(comment.ToGlobal());
        }

        public void Update(int id, Comment comment)
        {
            _commentRepository.Update(id, comment.ToGlobal());
        }
    }
}
