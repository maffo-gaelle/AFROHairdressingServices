using HairdressingServices.Api.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.Api.Models.Global.Repositories
{
    public interface IUserLocalityRepository
    {
        void Add(UserLocality userLocality);
        void Delete(string codePostal, int UserId);
        IEnumerable<Locality> GetAllLocalitiesByUser(int userId);
    }
}
