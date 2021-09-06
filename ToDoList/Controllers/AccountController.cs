using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoList.Dal;
using ToDoList.Domain;
using ToDoList.Dto;

namespace ToDoList.Api
{
    //[Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAuthRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IHashing hashing;
        private readonly IMapper mapper;

        public AccountController(IAuthRepository repository, IUserRepository userRepository, IHashing hashing, IMapper mapper)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.hashing = hashing;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            else
                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                password = hashing.GetHash(password);
                var user = repository.GetByEmailAndPassword(email,password);
                if (user != null)
                {
                    await Authenticate(user);

                    return Redirect("../Task/List");
                }
                ModelState.AddModelError("", "некоректний логін або пароль");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            else
                return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserCreateDto userCreateDto)
        {
            if (ModelState.IsValid)
            {
                userCreateDto.Password = hashing.GetHash(userCreateDto.Password);
                var userСheck = repository.GetByEmail(userCreateDto.Email);
                if (userСheck == null)
                {
                    var user = mapper.Map<User>(userCreateDto);
                    var result = userRepository.Create(user);
                    await Authenticate(result);
                    return Redirect("../Task/List");
                }
                else
                    ModelState.AddModelError("", "некоректний логін або пароль");
            }
            return View();
        }


        private async System.Threading.Tasks.Task Authenticate(User user)
        {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim("FirstName", user.LastName),
                    new Claim(ClaimTypes.Email, user.Email),
                };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

    }
}
