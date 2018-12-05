using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PubProjectApi.Models;
using PubProjectApi.Models.ModelsView;
using PubProjectApi.Models.ModelsView.Account;

namespace PubProjectClient.Controllers
{
    [Authorize]
    public class Account2Controller : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public Account2Controller(UserManager<AppUser> userManager,
                                    SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(Login login)
        {
           // _signInManager.SignOutAsync();
           // var result = _signInManager.PasswordSignInAsync(login.Email, login.Password, false, lockoutOnFailure: false);

            string urlGeneratePdfPriceLists = "http://localhost:64832/api/Account/Login";
            using (var client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(login);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var resp = client.PostAsync(urlGeneratePdfPriceLists, content).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return View("../Home/Index");
                }
            }
            //if (result.Result.Succeeded)
            //{
            //    return View("../Home/Index");
            //}

            return View(login);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(NewUser model )
        {
            if (ModelState.IsValid)
            {

                string urlGeneratePdfPriceLists = "http://localhost:64832/api/Account/Register";
                using (var client = new HttpClient())
                {
                    var jsonString = JsonConvert.SerializeObject(model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var resp = client.PostAsync(urlGeneratePdfPriceLists, content).Result;

                    if (resp.IsSuccessStatusCode)
                    {
                        return View();
                    }

                    
                }
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Logout ()
        {
            //string urlGeneratePdfPriceLists = "http://localhost:64832/api/Account/Logout";

            //using (var client = new HttpClient())
            //{
            //   var result = client.GetAsync(urlGeneratePdfPriceLists).Result;
            //}

            _signInManager.SignOutAsync();
            return View("Login");
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            string urlGeneratePdfPriceLists = "http://localhost:64832/api/GetByUser/" + id.ToString();
            using (var client = new HttpClient())
            {
                var resp = client.GetAsync(urlGeneratePdfPriceLists).GetAwaiter().GetResult();
                string mycontent = resp.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                NewUser result = Newtonsoft.Json.JsonConvert.DeserializeObject<NewUser>(mycontent);
                
                return View(result);
            }
        }

        [HttpPost]
        public IActionResult Edit(NewUser user)
        {
            string urlGeneratePdfPriceLists = "http://localhost:64832/api/Account/Edit";
            using (var client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(user);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var resp = client.PostAsync(urlGeneratePdfPriceLists, content).Result;

            }

            return View(user.GastronomicVenue.UserId);
        }
    }
}