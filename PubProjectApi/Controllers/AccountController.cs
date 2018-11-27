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
        private readonly IGastronomicVenuesService _gastronomicVenuesService;

        public AccountController(IAccountService accountService,IGastronomicVenuesService gastronomicVenuesService)
        {
            _accountService = accountService;
            _gastronomicVenuesService = gastronomicVenuesService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IActionResult> Register ([FromBody] NewUser model)
        {
            var user = new AppUser { Email = model.Email, Active = true ,UserName=model.Email};
            string role = "User";
            if (!String.IsNullOrEmpty(model.GastronomicVenue.GastronomicVenueName))
                role = "GastronomicVenueOwner";
            
            var result = _accountService.Register(user, model.Password, role).Result;


            if (role.Equals("GastronomicVenueOwner") && result.Succeeded)
            {
                model.GastronomicVenue.UserId = new Guid(user.Id);
                _gastronomicVenuesService.AddVenue(model.GastronomicVenue);
            }

            if (result.Succeeded)
            {
                return Ok();
            }

            return StatusCode(409);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
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

        public async Task Logout()
        {
            await _accountService.Logout();

        }
    }
}