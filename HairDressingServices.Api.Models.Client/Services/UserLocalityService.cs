using HairDressingServices.Api.Models.Client.Data;
using GR = HairdressingServices.Api.Models.Global.Repositories;
using HairDressingServices.Api.Models.Client.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HairDressingServices.Api.Models.Client.Repositories;

namespace HairDressingServices.Api.Models.Client.Services
{
    public class UserLocalityService : IUserLocalityRepository
    {
        private readonly GR.IUserLocalityRepository _userLocalityRepository;

        public UserLocalityService(GR.IUserLocalityRepository userLocalityRepository)
        {
            _userLocalityRepository = userLocalityRepository;
        }

        public void Add(UserLocality userLocality)
        {
            _userLocalityRepository.Add(userLocality.ToGlobal());
        }

        public void Delete(string codePostal, int UserId)
        {
            _userLocalityRepository.Delete(codePostal, UserId);
        }

        public IEnumerable<Locality> GetAllLocalitiesByUser(int userId)
        {
            return _userLocalityRepository.GetAllLocalitiesByUser(userId).Select(l => l.ToClient());
        }
    }
}
