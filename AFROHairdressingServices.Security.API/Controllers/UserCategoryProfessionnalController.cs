using HairDressingServices.Api.Models.Client.Repositories;
using HairDressingServices.Api.Models.Client.Data;
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
    public class UserCategoryProfessionnalController : ControllerBase
    {
        private readonly IUserCategoryProfessionnalRepository _userCategoryProfessionnal;

        public UserCategoryProfessionnalController(IUserCategoryProfessionnalRepository userCategoryProfessionnal)
        {
            _userCategoryProfessionnal = userCategoryProfessionnal;
        }

        // GET: api/<UserCategoryProfessionnalController>
        [HttpGet("GetUsers/Id")]
        public IEnumerable<User> GetUsers(int Id)
        {
            return _userCategoryProfessionnal.GetUsersByProfessionnalCategory(Id);
        }

        // GET api/<UserCategoryProfessionnalController>/5
        [HttpGet("{id}")]
        public ProfessionnalCategory Get(int id)
        {
            return _userCategoryProfessionnal.GetProfessionnalCategoryNameById(id);
        }

        // POST api/<UserCategoryProfessionnalController>
        [HttpPost]
        public void Post(UserCategoryProfessionnal userCategory)
        {
            _userCategoryProfessionnal.Add(userCategory);
        }


        // DELETE api/<UserCategoryProfessionnalController>/5
        [HttpDelete("{userId}/{id}")]
        public void Delete(int userId, int id)
        {
            _userCategoryProfessionnal.delete(userId, id);
        }
    }
}
