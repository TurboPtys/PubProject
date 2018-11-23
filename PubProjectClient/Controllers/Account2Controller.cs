using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PubProjectApi.Models.ModelsView;
using PubProjectApi.Models.ModelsView.Account;

namespace PubProjectClient.Controllers
{
    public class Account2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            string urlGeneratePdfPriceLists = "http://localhost:64832/api/Account/Login";
            using (var client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(login);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var resp = client.PostAsync(urlGeneratePdfPriceLists, content).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return View();
                }
            }

            return View(login);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
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
    }
}