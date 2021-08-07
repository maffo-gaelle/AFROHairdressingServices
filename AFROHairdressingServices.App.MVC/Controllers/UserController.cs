using AFROHairdressingServices.App.MVC.Infrastructures.Session;
using AFROHairdressingServices.App.MVC.Models.Form;
using AFROHairdressingServices.App.MVC.Models.Form.UserForm;
using HairdressingServices.MVC.Client.Data;
using HairdressingServices.MVC.Client.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.App.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly IProfessionnalCategoryRepository _professionnalCategoryRepository;
        private readonly IUserCategoryProfessionnalRepository _userCategoryProfessionnalRepository;
        private readonly ISessionManager _sessionManager;

        public UserController(IAuthRepository authRepository, IProfessionnalCategoryRepository professionnalCategoryRepository, IUserCategoryProfessionnalRepository userCategoryProfessionnalRepository, ISessionManager sessionManager)
        {
            _authRepository = authRepository;
            _professionnalCategoryRepository = professionnalCategoryRepository;
            _userCategoryProfessionnalRepository = userCategoryProfessionnalRepository;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult ProfessionnalHome ()
        {
            if (_sessionManager.User is null)
                return RedirectToAction("Login");

           User user = _authRepository.Get(_sessionManager.User.Id);

           foreach(int id in user.UserProfessionnalCategories)
            {
                ProfessionnalCategory p = _professionnalCategoryRepository.Get(id);
                user.ProfessionnalCategories.Add(p);
            }

            return View(user);
        }

        public IActionResult MemberHome()
        {
            if (_sessionManager.User is null)
                return RedirectToAction("Login");



            return View();
        }

        public IActionResult LoginClient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginClient(LoginForm form)
        {
            if(!ModelState.IsValid)
                return View(form);
            User user = _authRepository.LoginClient(form.Email, form.Passwd);
            if(user is null)
            {
                ModelState.AddModelError("", "Email ou mot de passe invalide !");
                return View(form);
            }

            if (user.Token is null)
            {
                ModelState.AddModelError("", "Veuillez vous connecter à votre espace client !");
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

        public IActionResult LoginProfessionnal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginProfessionnal(LoginForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            if (!_authRepository.EmailExists(form.Email))
                ModelState.AddModelError("", "Vous n'êtes pas encore incrit! Veuillez vous inscrire. ");

            User user = _authRepository.LoginProfessionnal(form.Email, form.Passwd);

            if (user is null)
            {
                ModelState.AddModelError("", "Email ou mot de passe invalide !");
                return View(form);
            }

            if (user.Token is null)
            {
                ModelState.AddModelError("", "Veuillez vous connecter à votre espace professionnel !");
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

            return RedirectToAction("ProfessionnalHome");
        }

        public IActionResult RegisterProfessionnal()
        {
            RegisterProfessionnalForm form = new RegisterProfessionnalForm();
            form.PersonnalCategories = GetCategoriesProfessionnal();

            return View(form);
        }

        [HttpPost]
        public IActionResult RegisterProfessionnal(RegisterProfessionnalForm form, string[] PersonnalCategories)
        {
            if(!ModelState.IsValid)
            {
                form.PersonnalCategories = GetCategoriesProfessionnal();
                return View(form);
            }

            
            if (!PersonnalCategories.Any())
            {
                form.PersonnalCategories = GetCategoriesProfessionnal();
                return View(form);
            }
            else
            {
                User newUser = _authRepository.RegisterProfessionnal(new User(form.Lastname, form.Firstname, form.Pseudo, form.Email, form.Passwd, form.Role, form.BirthDate, form.Description));

                User user = _authRepository.GetUserByPseudo(newUser.Pseudo);

                foreach(string item in PersonnalCategories)
                {
                    ProfessionnalCategory professionnalCategory = _professionnalCategoryRepository.Get(int.Parse(item));
                    UserCategoryProfessionnal ucp = new UserCategoryProfessionnal(user.Id, professionnalCategory.Id);

                    _userCategoryProfessionnalRepository.Add(ucp);
                    newUser.ProfessionnalCategories.Add(professionnalCategory);
                        
                }
            }
               
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RegisterMember()
        {
            RegisterMemberForm form = new RegisterMemberForm();

            return View(form);
        }

        [HttpPost]
        public IActionResult RegisterMember(RegisterMemberForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            _authRepository.RegisterMember(new User(form.Lastname, 
                                                    form.Firstname, 
                                                    form.Pseudo, 
                                                    form.Email, 
                                                    form.Passwd, 
                                                    form.Role, 
                                                    form.BirthDate,
                                                    form.Description
                                                    ));

            return RedirectToAction("Index", "Home");
        }

        private SelectListItem[] GetCategoriesProfessionnal()
        {
            return _professionnalCategoryRepository.GetAll()
                                                    .Select(c => new SelectListItem(c.NameCategory, c.Id.ToString())).ToArray();
                                                    //{
                                                    //    Selected = (id.HasValue && c.Id == id.Value)
                                                    //}).ToArray();
        }

        public ActionResult Logout()
        {
            _sessionManager.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
