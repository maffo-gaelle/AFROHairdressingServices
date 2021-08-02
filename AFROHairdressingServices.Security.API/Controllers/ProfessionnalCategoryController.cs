using AFROHairdressingServices.Security.API.Models.Forms.ProfessionnalCategoryForm;
using HairDressingServices.Api.Models.Client.Data;
using HairDressingServices.Api.Models.Client.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFROHairdressingServices.Security.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionnalCategoryController : ControllerBase
    {
        private readonly IProfessionnalCategoryRepository _professionnalCategoryRepository;

        public ProfessionnalCategoryController(IProfessionnalCategoryRepository professionnalCategoryRepository)
        {
            _professionnalCategoryRepository = professionnalCategoryRepository;
        }

        // GET: api/<ProfessionnalCategoryController>
        [HttpGet]
        public IEnumerable<ProfessionnalCategory> Get()
        {
            return _professionnalCategoryRepository.GetAll();
        }

        // GET api/<ProfessionnalCategoryController>/5
        [HttpGet("{id}")]
        public ProfessionnalCategory Get(int id)
        {
            return _professionnalCategoryRepository.Get(id);
        }

        // POST api/<ProfessionnalCategoryController>
        [HttpPost]
        public void Post([FromBody] CreateProfessionnalCategoryForm form)
        {
            _professionnalCategoryRepository.Add(form.NameCategory);
        }

        // PUT api/<ProfessionnalCategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UpdateProfessionnalCategoryForm form)
        {
            _professionnalCategoryRepository.Update(id, new ProfessionnalCategory(form.NameCategory));
        }

        // DELETE api/<ProfessionnalCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _professionnalCategoryRepository.Delete(id);
        }

        [HttpGet("GetUsers/{id}")]
        public IEnumerable<User> GetUsersByProfessionnalCategory(int id)
        {
            return _professionnalCategoryRepository.GetUsersByProfessionnalCategory(id);
        }

        [HttpGet("{name}")]
        public ProfessionnalCategory Get(string name)
        {
            return _professionnalCategoryRepository.GetProfessionnalCategoryByName(name);
        }


    }
}
