using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PubProjectApi.Models;
using PubProjectApi.Models.ModelsView;
using PubProjectApi.Models.ModelsView.Account;

namespace PubProjectApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        [HttpPost]
        [Route("Register")]
        public async Task<IdentityResult> Register([FromBody] NewUser model)
        {
            var user = new AppUser { Email = model.Email, Active = true };
            var result = await _userManager.CreateAsync(user, model.Password);
            return result;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(Login login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, lockoutOnFailure: false);
            return result;
        }
    }
}