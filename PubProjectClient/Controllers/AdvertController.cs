using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PubProjectApi.Models;
using PubProjectApi.Models.ModelsView;
using PubProjectApi.Models.ModelsView.Advert;

namespace PubProjectClient.Controllers
{
    [Route("[controller]/[action]")]
    public class AdvertController : Controller
    {
        private readonly IHostingEnvironment _environment;

        public AdvertController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

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

                if (model.SearchAdvert.Date.HasValue)
                    query["date"] = model.SearchAdvert.Date.Value.ToString("yyyyMMddHHmmss");

                builder.Query = query.ToString();

                var resp = client.GetAsync(builder.Uri).Result;

                string mycontent = resp.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                IEnumerable<AdvertisementListView> result = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<AdvertisementListView>>(mycontent);

                AdvertsListView adv = new AdvertsListView { Adverts = result, SearchAdvert = new SearchAdvert() };
                return View("Index", adv);
            }
        }

        [Authorize(Roles = "GastronomicVenueOwner")]
        public IActionResult AddAdvert()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "GastronomicVenueOwner")]
        //public IActionResult AddAdvert(AddAdvert advertisement, IFormFile pic)
        public IActionResult AddAdvert(AddAdvert advert, Guid OwnerId)
        {

            string urlGeneratePdfPriceLists = "http://localhost:64832/api/Advertisement";
            using (var client = new HttpClient())
            {


                try
                {


                    byte[] data;
                    using (var br = new BinaryReader(advert.File.OpenReadStream()))
                        data = br.ReadBytes((int)advert.File.OpenReadStream().Length);

                    ByteArrayContent bytes = new ByteArrayContent(data);


                    MultipartFormDataContent multiContent = new MultipartFormDataContent();

                    multiContent.Add(bytes, "File", advert.File.FileName);
                    multiContent.Add(new StringContent(advert.DateEvent.ToString()), "DateEvent");
                    multiContent.Add(new StringContent(advert.Discription), "Discription");
                    multiContent.Add(new StringContent(OwnerId.ToString()), "OwnerId");
                    multiContent.Add(new StringContent(advert.Title), "Title");
                    multiContent.Add(new StringContent(advert.Tag), "Tag");
                  

                    var result = client.PostAsync(urlGeneratePdfPriceLists, multiContent).Result;


                    if (result.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index", "Advert");

                    }
                     //201 Created the request has been fulfilled, resulting in the creation of a new resource.

                }
                catch (Exception)
                {
                    return StatusCode(500); // 500 is generic server error
                }

                //byte[] data;
                //using (var br = new BinaryReader(advert.F.OpenReadStream()))
                //    data = br.ReadBytes((int)advert.F.OpenReadStream().Length);

                ////var jsonString = JsonConvert.SerializeObject(a);
                ////var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                
                //ByteArrayContent bytes = new ByteArrayContent(data);
                //MultipartFormDataContent multiContent = new MultipartFormDataContent();
                //multiContent.Add(bytes, "file", advert.F.FileName);
                //multiContent.Add(new StringContent(advert.DateEvent.ToString()), "DateEvent");
                //multiContent.Add(new StringContent(advert.Discription), "Discription");

                //var resp = client.PostAsync(urlGeneratePdfPriceLists, multiContent).Result;

                return View();
            }

        }

        [HttpGet]
        [Route("{UserId}/{AdvertId}")]
        public IActionResult AddLike(Guid UserId, Guid AdvertId)
        {

            string urlGeneratePdfPriceLists = "http://localhost:64832/api/Advertisement/AddLike";
            using (var client = new HttpClient())
            {
                UriBuilder builder = new UriBuilder(urlGeneratePdfPriceLists);
                AddLike addLike = new AddLike { AdvertId = AdvertId, UserId = UserId };

                var jsonString = JsonConvert.SerializeObject(addLike);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var resp = client.PostAsync(builder.Uri,content).Result;

                return RedirectToAction("Index", "Advert");
            }
        }
    }
}