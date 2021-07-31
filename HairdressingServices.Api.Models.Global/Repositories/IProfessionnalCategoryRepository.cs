using HairdressingServices.Api.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.Api.Models.Global.Repositories
{
    public interface IProfessionnalCategoryRepository
    {
        ProfessionnalCategory Get(int Id);
        ProfessionnalCategory GetProfessionnalCategoryByName(string name);
        IEnumerable<ProfessionnalCategory> GetAll();
        void Insert(ProfessionnalCategory category);
        void Update(int userid, ProfessionnalCategory category);
        void Delete(int userid, int id);


    }
}
