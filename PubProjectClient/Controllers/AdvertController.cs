using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PubProjectApi.Models;
using PubProjectApi.Models.ModelsView;
using PubProjectApi.Models.ModelsView.Advert;

namespace PubProjectClient.Controllers
{
    public class AdvertController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string urlGeneratePdfPriceLists = "http://localhost:64832/api/Advertisement/AdvertisementList";
            using (var client = new HttpClient())
            {
                var resp = client.GetAsync(urlGeneratePdfPriceLists).GetAwaiter().GetResult();
                string mycontent = resp.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                IEnumerable<AdvertisementListView> result = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<AdvertisementListView>>(mycontent);

                AdvertsListView model = new AdvertsListView { Adverts = result, SearchAdvert = new SearchAdvert() };
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Search(AdvertsListView model)
        {
            string urlGeneratePdfPriceLists = "http://localhost:64832/api/Advertisement/Search";
            using (var client = new HttpClient())
            {
                UriBuilder builder = new UriBuilder(urlGeneratePdfPriceLists);
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["city"] = model.SearchAdvert.City;

                if(model.SearchAdvert.Date.HasValue)
                    query["date"] = model.SearchAdvert.Date.Value.ToString("yyyyMMddHHmmss");

                builder.Query = query.ToString();

                var resp = client.GetAsync(builder.Uri).Result;

                string mycontent = resp.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                IEnumerable<AdvertisementListView> result = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<AdvertisementListView>>(mycontent);

                AdvertsListView adv = new AdvertsListView { Adverts = result, SearchAdvert = new SearchAdvert() };
                return View("Index", adv);
            }
        }

        [Authorize]
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