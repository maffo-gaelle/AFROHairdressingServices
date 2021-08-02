using HairdressingServices.MVC.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.MVC.Global.Repositories
{
    public interface IAvisRepository
    {
        Avis Get(int id);
        IEnumerable<Avis> GetAllAvisByProfessionnal(int professionnalId);
        bool Insert(Avis avis);
        bool Update(int id, Avis avis);
        IEnumerable<Comment> GetAllCommentByAvis(int id);
    }
}
