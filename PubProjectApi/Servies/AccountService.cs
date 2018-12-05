using Microsoft.AspNetCore.Identity;
using PubProjectApi.Models;
using PubProjectApi.Models.ModelsView;
using PubProjectApi.Models.ModelsView.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Servies
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> Register(AppUser user, string Password, string Role)
        {

            var result = await _userManager.CreateAsync(user, Password);
            if (result.Succeeded)
            {
                bool adminRoleExists = await _roleManager.RoleExistsAsync(Role);
                 IdentityResult roleResult;
                if (!adminRoleExists)
                {
                    roleResult = await _roleManager.CreateAsync(new IdentityRole(Role));
                }

                if (!await _userManager.IsInRoleAsync(user, Role))
                {
                    //_logger.LogInformation("Adding sysadmin to Admin role");
                    var userResult = await _userManager.AddToRoleAsync(user, Role);
                }
                //var aa = await _userManager.AddToRoleAsync(user, Role);
               var a = await _signInManager.PasswordSignInAsync(user.Email, Password, false, lockoutOnFailure: false);
            }
            return result;
        }

        public async Task<SignInResult> Login(Login user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, lockoutOnFailure: false);
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();

        }

    }
}
