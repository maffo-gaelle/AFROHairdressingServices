using HairDressingServices.Api.Models.Client.Data;
using HairDressingServices.Api.Models.Client.Mappers;
using HairDressingServices.Api.Models.Client.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GR = HairdressingServices.Api.Models.Global.Repositories;


namespace HairDressingServices.Api.Models.Client.Services
{
    public class ProfessionnalCategoryService : IProfessionnalCategoryRepository
    {
        private readonly GR.IProfessionnalCategoryRepository _categoryRepository;

        public ProfessionnalCategoryService(GR.IProfessionnalCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ProfessionnalCategory Get(int Id)
        {
            return _categoryRepository.Get(Id).ToClient();
        }

        public IEnumerable<ProfessionnalCategory> GetAll()
        {
            return _categoryRepository.GetAll().Select(cp => cp.ToClient());
        }

        public void Add(string name)
        {
             _categoryRepository.Add(name);
        }

        public void Update(int id, ProfessionnalCategory category)
        {
            _categoryRepository.Update(id, category.ToGlobal());
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }

        public ProfessionnalCategory GetProfessionnalCategoryByName(string name)
        {
            return _categoryRepository.GetProfessionnalCategoryByName(name).ToClient();
        }

        public IEnumerable<User> GetUsersByProfessionnalCategory(int categoryId)
        {
            return _categoryRepository.GetUsersByProfessionnalCategory(categoryId).Select(u => u.ToClient());
        }

    }
}
