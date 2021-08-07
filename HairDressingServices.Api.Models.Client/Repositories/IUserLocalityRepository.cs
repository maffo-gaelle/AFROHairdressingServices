using HairDressingServices.Api.Models.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDressingServices.Api.Models.Client.Repositories
{
    public interface IUserLocalityRepository
    {
        void Add(UserLocality userLocality);
        void Delete(string codePostal, int UserId);
        IEnumerable<Locality> GetAllLocalitiesByUser(int userId);
    }
}
