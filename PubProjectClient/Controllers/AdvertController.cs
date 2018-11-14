using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PubProjectApi.Models;

namespace PubProjectClient.Controllers
{
    public class AdvertController : Controller
    {
        public IActionResult Index()
        {
            string urlGeneratePdfPriceLists = "http://localhost:64832/api/Advertisement";
            using (var client = new HttpClient())
            {
                var resp = client.GetAsync(urlGeneratePdfPriceLists).GetAwaiter().GetResult();
                string mycontent = resp.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                IEnumerable<Advertisement> result = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Advertisement>>(mycontent);
                return View(result);
            }
        }


    }
}