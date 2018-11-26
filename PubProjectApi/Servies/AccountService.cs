﻿using Microsoft.AspNetCore.Identity;
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


        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Register(AppUser user, string Password, string Role)
        {

            var result = await _userManager.CreateAsync(user, Password);
            if (result.Succeeded)
            {
               var aa = await _userManager.AddToRoleAsync(user, Role);
               await _signInManager.PasswordSignInAsync(user.Email, Password, false, lockoutOnFailure: false);
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
