using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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


    }
}