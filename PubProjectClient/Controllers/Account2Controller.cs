using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PubProjectApi.Models.ModelsView;

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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(NewUser model )
        {

            string urlGeneratePdfPriceLists = "http://localhost:64832/api/Register";
            using (var client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var resp = client.PostAsync(urlGeneratePdfPriceLists, content).Result;

                return View();
            }

        }
    }
}