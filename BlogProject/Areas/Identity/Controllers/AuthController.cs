using BlogProject.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly LoginViewModelMapper _loginViewModelMapper;
        private readonly IUserManager _userManager;
        public AuthController(SignInManager<IdentityUser> signInManager, LoginViewModelMapper loginViewModelMapper, IUserManager userManager)
        {
            _signInManager = signInManager;
            _loginViewModelMapper = loginViewModelMapper;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVm)
        {
            var loginDto = _loginViewModelMapper.Map(loginVm);
            await _userManager.LoginUser(loginDto);
            return RedirectToAction("Index", "Home", new {area = "Admin" });
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
