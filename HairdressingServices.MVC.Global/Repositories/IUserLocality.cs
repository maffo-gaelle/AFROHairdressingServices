using HairdressingServices.MVC.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.MVC.Global.Repositories
{
    public interface IUserLocality
    {
        void Add(UserLocality userLocality);
        void Delete(string codePostal, int UserId);
        IEnumerable<Locality> GetAllLocalitiesByUser(int userId);
    }
}
