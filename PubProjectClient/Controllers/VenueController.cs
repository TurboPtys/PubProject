﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PubProjectApi.Models;

namespace PubProjectClient.Controllers
{
    public class VenueController : Controller
    {
        public IActionResult Index()
        {

            string urlGeneratePdfPriceLists = "http://localhost:64832/api/GastronomicVenue";
            using (var client = new HttpClient())
            {
                var resp = client.GetAsync(urlGeneratePdfPriceLists).GetAwaiter().GetResult();
                string mycontent = resp.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                IEnumerable<GastronomicVenue> result = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<GastronomicVenue>>(mycontent);
                return View(result);
            }

           
        }
    }
}