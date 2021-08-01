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
    public class AvisService : IAvisRepository
    {
        public readonly GR.IAvisRepository _avisRepository;

        public AvisService(GR.IAvisRepository avisRepository)
        {
            _avisRepository = avisRepository;
        }

        public Avis Get(int id)
        {
            return _avisRepository.Get(id).ToClient();
        }

        public IEnumerable<Avis> GetAllAvisByProfessionnal(int professionnalId)
        {
            return _avisRepository.GetAllAvisByProfessionnal(professionnalId).Select(a => a.ToClient());
        }

        public IEnumerable<Comment> GetAllCommentByAvis(int id)
        {
            return _avisRepository.GetAllCommentByAvis(id)?.Select(c => c.ToClient());
        }

        public void Insert(Avis avis)
        {
            _avisRepository.Insert(avis.ToGlobal());
        }

        public void Update(int id, Avis avis)
        {
            _avisRepository.Update(id, avis.ToGlobal());
        }
    }
}
