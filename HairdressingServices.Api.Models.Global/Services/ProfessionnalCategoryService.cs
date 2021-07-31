using HairdressingServices.Api.Models.Global.Data;
using HairdressingServices.Api.Models.Global.Mappers;
using HairdressingServices.Api.Models.Global.Repositories;
using HairdressingServices.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.Api.Models.Global.Services
{
    public class ProfessionnalCategoryService : IProfessionnalCategoryRepository
    {
        private readonly Connection _connection;

        public ProfessionnalCategoryService(Connection connection)
        {
            _connection = connection;
        }

        public ProfessionnalCategory Get(int Id)
        {
            Command command = new Command("SELECT * FROM HDP_AllProfessionnalCategories WHERE Id = @Id", false);
            command.AddParameter("Id", Id);

            return _connection.ExecuteReader(command, dr => dr.ToProfessionnalCategory()).FirstOrDefault();
        }

        public IEnumerable<ProfessionnalCategory> GetAll()
        {
            Command command = new Command("HDP_AllProfessionnalCategories", false);

            return _connection.ExecuteReader(command, dr => dr.ToProfessionnalCategory());
        }

        public void Add(string name)
        {
            Command command = new Command("HDP_AddProfessionnalCategory", true);
            command.AddParameter("Name", name);

            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int id)
        {
            Command command = new Command("HDP_DeleteProfessionnalCategory", true);
            command.AddParameter("Id", id);

            _connection.ExecuteNonQuery(command);
        }

        public void Update(ProfessionnalCategory category)
        {
            int Id = category.Id;
            string Name = category.NameCategory;
            Command command = new Command("HDP_UpdateProfessionnalCategory", true);
            command.AddParameter("Id", Id);
            command.AddParameter("Name", Name);

            _connection.ExecuteNonQuery(command);
        }

        public ProfessionnalCategory GetProfessionnalCategoryByName(string name)
        {
            Command command = new Command("HDP_GetProfessionnalCategoryByName", true);
            command.AddParameter("Name", name);

            return _connection.ExecuteReader(command, dr => dr.ToProfessionnalCategory()).FirstOrDefault();
        }

        public IEnumerable<User> GetUsersByProfessionnalCategory(int categoryId) 
        {
            Command command = new Command("HDP_GetUsersByProfessionnalCategory", true);
            command.AddParameter("IdProfessionnalCategory", categoryId);

            return _connection.ExecuteReader(command, dr => dr.ToUser());
        }

    }
}
