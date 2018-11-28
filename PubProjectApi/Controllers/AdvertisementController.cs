using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PubProjectApi.Models;
using PubProjectApi.Models.ModelsView;
using PubProjectApi.Models.ModelsView.Advert;
using PubProjectApi.Repository.Interface;
using PubProjectApi.Servies;

namespace PubProjectApi.Controllers
{
    [Route("api/Advertisement")]
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementService _advertisementServiecs;
        private readonly ILikeService _likeService;

        public AdvertisementController(IAdvertisementService advertisementService, ILikeService likeService)
        {
            _advertisementServiecs = advertisementService;
            _likeService = likeService;
        }

        [HttpGet]
        [Route("AdvertisementList")]
        public async Task<IActionResult> AdvertisementList()
        {
            var adv = await _advertisementServiecs.GetAdvertsList();
            return Ok(adv);
        }

        [HttpGet]
        [Route("Search")]
        [Route("{city}/{date}")]
        public async Task<IActionResult> AdvertisementList(string city, string date)
        {
            DateTime? d = null;
            if (!String.IsNullOrEmpty(date)) {
                d = DateTime.ParseExact(date, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            }

            IEnumerable<AdvertisementListView> adv;

            if (String.IsNullOrEmpty(date) && String.IsNullOrEmpty(city))
            {
                adv = await _advertisementServiecs.GetAdvertsList();
            }
            else if (String.IsNullOrEmpty(date))
            {
                adv = (await _advertisementServiecs.GetAdvertsList()).Where(x => x.GastronomicVenue.City.Equals(city));
            }
            else
            {
                adv = (await _advertisementServiecs.GetAdvertsList()).Where(x => x.Advertisement.EventDate.Date == d.Value.Date);
            }

            return Ok(adv);
        }

        // GET: api/Advertisement
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var advertisements = await _advertisementServiecs.GetAll();
            return Ok(advertisements);
        }

        // GET: api/Advertisement/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Advertisement
        [HttpPost]
        public void Post([FromBody] AddAdvert advertisement)
        {
            var adv = new Advertisement { Title = advertisement.Title, Description = advertisement.Discription, EventDate = advertisement.DateEvent };
            _advertisementServiecs.AddAdvert(adv);
        }

        [HttpPost]
        [Route("AddLike")]
        public void AddLike([FromBody] AddLike addLike)
        {
            _likeService.AddLike(addLike);
        }
    }
}
