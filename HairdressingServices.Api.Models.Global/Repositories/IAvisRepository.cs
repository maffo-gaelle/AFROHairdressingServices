using HairdressingServices.Api.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.Api.Models.Global.Repositories
{
    public interface IAvisRepository
    {
        Avis Get(int userid, int id);
        IEnumerable<Avis> GetAvisByProfessionnal(int userId, int professionnalId);
        void Insert(Avis avis);
        void UpdateAvis(int userid, int id);
        int AverageStarsAvis(int professionnalId);
    }
}
