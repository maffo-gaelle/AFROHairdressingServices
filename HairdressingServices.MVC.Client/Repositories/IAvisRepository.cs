using HairdressingServices.MVC.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.MVC.Client.Repositories
{
    public interface IAvisRepository
    {
        Avis Get(int id);
        IEnumerable<Avis> GetAllAvisByProfessionnal(int professionnalId);
        void Insert(Avis avis);
        void Update(int id, Avis avis);
        IEnumerable<Comment> GetAllCommentByAvis(int id);
    }
}
