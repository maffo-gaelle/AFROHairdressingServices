using HairDressingServices.Api.Models.Client.Data;
using HairDressingServices.Api.Models.Client.Repositories;
using System;
using System.Collections.Generic;
using GR = HairdressingServices.Api.Models.Global.Repositories;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HairDressingServices.Api.Models.Client.Mappers;

namespace HairDressingServices.Api.Models.Client.Services
{
    public class LocalityService : ILocalityRepository
    {
        private readonly GR.ILocalityRepository _localityRepository;

        public LocalityService(GR.ILocalityRepository localityRepository)
        {
            _localityRepository = localityRepository;
        }

        public void Add(Locality locality)
        {
            _localityRepository.Add(locality.ToGlobal());
        }

        public void Delete(string codePostal)
        {
            _localityRepository.Delete(codePostal);
        }

        public bool ExistsLocality(Locality locality)
        {
            return _localityRepository.ExistsLocality(locality.ToGlobal());
        }

        public Locality Get(string codePostal)
        {
            return _localityRepository.Get(codePostal).ToClient();
        }

        public IEnumerable<Locality> Get()
        {
            return _localityRepository.Get().Select(l => l.ToClient());
        }

        public void Update(Locality locality)
        {
            _localityRepository.Update(locality.ToGlobal());
        }
    }
}
