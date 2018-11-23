using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PubProjectApi.Models;
using PubProjectApi.Models.ModelsView;
using PubProjectApi.Models.ModelsView.Account;
using PubProjectApi.Servies;

namespace PubProjectApi.Controllers
{
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IActionResult> Register ([FromBody] NewUser model)
        {
            var user = new AppUser { Email = model.Email, Active = true ,UserName=model.Email};

            var result = await _accountService.Register(user, model.Password);
            if (result.Succeeded)
            {
                return Ok();
            }

            return StatusCode(409);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            var result = await _accountService.Login(login);
            if (result.Succeeded)
            {
                return Ok();
            }
            else if (result.IsLockedOut)
            {
                return Ok();
            }
            else
            {
                return StatusCode(404);
            }
        }
    }
}