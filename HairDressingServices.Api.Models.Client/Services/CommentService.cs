using HairDressingServices.Api.Models.Client.Data;
using HairDressingServices.Api.Models.Client.Mappers;
using HairDressingServices.Api.Models.Client.Repositories;
using GR = HairdressingServices.Api.Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDressingServices.Api.Models.Client.Services
{
    public class CommentService : ICommentRepository
    {
        private readonly GR.ICommentRepository _commentRepository;

        public CommentService(GR.ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
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
            return _commentRepository.GetUserComment(comment.ToGloblal()).ToClient();
        }

        public void Insert(Comment comment)
        {
            _commentRepository.Insert(comment.ToGloblal());
        }

        public void Update(int id, Comment comment)
        {
            _commentRepository.Update(id, comment.ToGloblal());
        }

        public void Delete(int userId, int id)
        {
            _commentRepository.Delete(userId, id);
        }
    }
}
