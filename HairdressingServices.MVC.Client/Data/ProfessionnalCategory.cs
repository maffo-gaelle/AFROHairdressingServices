using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.MVC.Client.Data
{
    public class ProfessionnalCategory
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }

        public ProfessionnalCategory(string nameCategory)
        {
            NameCategory = nameCategory;
        }

        public ProfessionnalCategory(int id, string nameCategory)
            : this(nameCategory)
        {
            Id = id;
        }
    }
}
