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
    public interface IAccountService
    {
        Task<IdentityResult> Register(AppUser user, string Password);

        Task<SignInResult> Login(Login user);
    }
}
