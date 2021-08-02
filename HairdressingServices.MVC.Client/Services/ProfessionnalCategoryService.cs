using HairdressingServices.MVC.Client.Repositories;
using GR = HairdressingServices.MVC.Global.Repositories;
using HairdressingServices.MVC.Client.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HairdressingServices.MVC.Client.Data;

namespace HairdressingServices.MVC.Client.Services
{
    public class ProfessionnalCategoryService : IProfessionnalCategoryRepository
    {
        public readonly GR.IProfessionnalCategoryRepository _professionnalCategoryRepository;

        public ProfessionnalCategoryService(GR.IProfessionnalCategoryRepository professionnalCategoryRepository)
        {
            _professionnalCategoryRepository = professionnalCategoryRepository;
        }

        public void Add(string name)
        {
            _professionnalCategoryRepository.Add(name);
        }

        public void Delete(int id)
        {
            _professionnalCategoryRepository.Delete(id);
        }

        public ProfessionnalCategory Get(int Id)
        {
            return _professionnalCategoryRepository.Get(Id).ToClient();
        }

        public IEnumerable<ProfessionnalCategory> GetAll()
        {
            return _professionnalCategoryRepository.GetAll().Select(cp => cp.ToClient());
        }

        public ProfessionnalCategory GetProfessionnalCategoryByName(string name)
        {
            return _professionnalCategoryRepository.GetProfessionnalCategoryByName(name).ToClient();
        }

        public IEnumerable<User> GetUsersByProfessionnalCategory(int categoryId)
        {
            return _professionnalCategoryRepository.GetUsersByProfessionnalCategory(categoryId).Select(u => u.ToClient());
        }

        public void Update(int id, ProfessionnalCategory category)
        {
            _professionnalCategoryRepository.Update(id, category.ToGlobal());
        }
    }
}
