using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PubProjectApi.Models;
using PubProjectApi.Models.ModelsView;

namespace PubProjectClient.Controllers
{
    public class AdvertController : Controller
    {
        public IActionResult Index()
        {
            string urlGeneratePdfPriceLists = "http://localhost:64832/api/Advertisement/AdvertisementList";
            using (var client = new HttpClient())
            {
                var resp = client.GetAsync(urlGeneratePdfPriceLists).GetAwaiter().GetResult();
                string mycontent = resp.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                IEnumerable<AdvertisementListView> result = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<AdvertisementListView>>(mycontent);
                return View(result);
            }

            //IEnumerable<AdvertsListView> model;
            //urlGeneratePdfPriceLists = "http://localhost:64832/api/GastronomicVenue/";
            //using (var cilent= new HttpClient())
            //{
            //}

            //return View(model);
        }

        public IActionResult AddAdvert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdvert(Advertisement advertisement)
        {
            string urlGeneratePdfPriceLists = "http://localhost:64832/api/Advertisement";
            using (var client = new HttpClient())
            {
                var adv = new Advertisement { Active = true, AdvertisementId = Guid.NewGuid(), DateAdded = DateTime.Now, Title = advertisement.Title, Description = advertisement.Description, GastronomicVenueId = new Guid("d71e759a-ce3e-4c57-b089-07c2274955d8"), Tag = "iło", Category = "fajno fajno" };

                var jsonString = JsonConvert.SerializeObject(adv);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var resp = client.PostAsync(urlGeneratePdfPriceLists, content).Result;

                return View();
            }

        }
    }
}