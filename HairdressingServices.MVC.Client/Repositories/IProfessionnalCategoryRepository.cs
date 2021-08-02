using HairdressingServices.MVC.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.MVC.Client.Repositories
{
    public interface IProfessionnalCategoryRepository
    {
        ProfessionnalCategory Get(int Id);
        ProfessionnalCategory GetProfessionnalCategoryByName(string name);
        IEnumerable<ProfessionnalCategory> GetAll();
        void Add(string name);
        void Update(int id, ProfessionnalCategory category);
        void Delete(int id);
        IEnumerable<User> GetUsersByProfessionnalCategory(int categoryId);
    }
}
