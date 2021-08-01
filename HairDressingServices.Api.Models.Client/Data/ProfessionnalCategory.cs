using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDressingServices.Api.Models.Client.Data
{
    public class ProfessionnalCategory
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }

        public ProfessionnalCategory(string nameCategory)
        {
            NameCategory = nameCategory;
        }

        internal ProfessionnalCategory(int id, string nameCategory)
            :this(nameCategory)
        {
            Id = id;
        }
    }
}
