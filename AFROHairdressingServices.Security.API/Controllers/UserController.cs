using AFROHairdressingServices.Security.API.Infrastructures.Security;
using AFROHairdressingServices.Security.API.Models.Forms.UserForm;
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
    public class UserController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenRepository _tokenRepository;

        public UserController(IAuthRepository authRepository, ITokenRepository tokenRepository)
        {
            _authRepository = authRepository;
            _tokenRepository = tokenRepository;
        }

        // GET: api/<UserController>
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginForm form)
        {
            User user = _authRepository.Login(form.Email, form.Passwd);

            if (user is null)
                return Unauthorized(new { Error = "Email ou mot de passe invalide!" });

            user.Token = _tokenRepository.GenerateToken(new TokenUser() 
            { 
                Id = user.Id, 
                Lastname = user.Lastname, 
                Firstname = user.Firstname, 
                Pseudo = user.Pseudo,
                Email = user.Email,
                Role = user.Role,
                BirthDate = user.BirthDate,
            });

            return Ok(user);
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterForm form)
        {
            _authRepository.Register(new User(form.Lastname, form.Firstname, form.Pseudo, form.Email, form.Passwd, form.Role, form.BirthDate));

            return NoContent();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _authRepository.Get(id);
        }

        [HttpGet("ByRole/{id}")]
        public IEnumerable<User> GetUsersByRole(int id)
        {
            return _authRepository.GetAllProfessionnalUsersOrMemberUsers(id);
        }

        [HttpGet("All")]
        public IEnumerable<User> GetAllUsers()
        {
            return _authRepository.GetAllUser();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UpdateUserForm form)
        {
            _authRepository.Update(id, new User(form.Lastname, form.Firstname, form.Pseudo, form.Email, form.Passwd, form.Role, form.BirthDate));

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _authRepository.Delete(id);
        }

        [HttpGet("professionnalCategories/{id}")]
        public IEnumerable<ProfessionnalCategory> GetAllProfessionnalCategoriesByUser(int id)
        {
            return _authRepository.AllProfessionnalCategoryOfUser(id);
        }

        [HttpGet("AllAvis/{id}")]
        public IEnumerable<Avis> GetAllAvisByProfessionnal(int id)
        {
            return _authRepository.GetAllAvisByProfessionnal(id);
        }

        // GET api/<UserController>/5
        [HttpGet("Average/{id}")]
        public int Average(int id)
        {
            return _authRepository.AverageStarsAvisByProfessionnal(id);
        }

        // GET api/<UserController>/5
        [HttpGet("countAvis/{id}")]
        public int Count(int id)
        {
            return _authRepository.CountAvisByProfessionnal(id);
        }

        // GET api/<UserController>/5
        [HttpGet("EmailExists/{email}")]
        public bool EmailExists(string email)
        {
            return _authRepository.EmailExists(email);
        }

        // GET api/<UserController>/5
        [HttpGet("pseudoExists/{pseudo}")]
        public bool PseudoExists(string pseudo)
        {
            return _authRepository.PseudoExists(pseudo);
        }

        // GET api/<UserController>/5
        [HttpGet("userByPseudo/{pseudo}")]
        public User GetUserByPseudo(string pseudo)
        {
            return _authRepository.GetUserByPseudo(pseudo);
        }

    }
}
