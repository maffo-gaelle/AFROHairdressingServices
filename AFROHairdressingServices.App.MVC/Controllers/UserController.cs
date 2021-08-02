using AFROHairdressingServices.App.MVC.Infrastructures.Session;
using AFROHairdressingServices.App.MVC.Models.Form;
using HairdressingServices.MVC.Client.Data;
using HairdressingServices.MVC.Client.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.App.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly ISessionManager _sessionManager;

        public UserController(IAuthRepository authRepository, ISessionManager sessionManager)
        {
            _authRepository = authRepository;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            if(!ModelState.IsValid)
                return View(form);
            User user = _authRepository.Login(form.Email, form.Passwd);
            if(user is null)
            {
                ModelState.AddModelError("", "Email ou mot de passe invalide !");
                return View(form);
            }

            _sessionManager.User = new UserSession()
            {
                Id = user.Id,
                Lastname = user.Lastname,
                Firstname = user.Firstname,
                Pseudo = user.Pseudo,
                Email = user.Email,
                BirthDate = user.BirthDate,
                Role = user.Role,
                Status = user.Status,
                Token = user.Token
            };

            return RedirectToAction("Index", "Home");
        }
    }
}
