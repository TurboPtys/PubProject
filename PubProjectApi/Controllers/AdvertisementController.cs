using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IGastronomicVenuesService _gastronomicVenuesService;
        private readonly ILikeService _likeService;
        private readonly IFileService _fileService;
        private readonly IHostingEnvironment _environment;

        public AdvertisementController(IAdvertisementService advertisementService, ILikeService likeService, IHostingEnvironment environment, IFileService fileService, IGastronomicVenuesService gastronomicVenuesService)
        {
            _advertisementServiecs = advertisementService;
            _likeService = likeService;
            _environment = environment;
            _fileService = fileService;
            _gastronomicVenuesService = gastronomicVenuesService;
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
        //[HttpPost]
        //public void Post([FromBody] AddAdvert advertisement)
        //{

        //    if (Request.HasFormContentType)
        //    {
        //        var form = Request.Form;
        //        foreach (var formFile in form.Files)
        //        {
        //            var targetDirectory = Path.Combine( _environment.WebRootPath, "uploads");
        //            var fileName = Path.Combine(_environment.WebRootPath, Path.GetFileName(advertisement.F.FileName));
        //            //var fileName = GetFileName(formFile);

        //            var savePath = Path.Combine(targetDirectory, fileName);

        //            using (var fileStream = new FileStream(savePath, FileMode.Create))
        //            {
        //                formFile.CopyTo(fileStream);
        //            }
        //        }
        //    }

        //    var adv = new Advertisement { Title = advertisement.Title, Description = advertisement.Discription, EventDate = advertisement.DateEvent };
        //    _advertisementServiecs.AddAdvert(adv);
        //}


        [HttpPost]
        public async Task<IActionResult>  Post(AddAdvert advert)
        {
            var venue = _gastronomicVenuesService.GetByOwnerId(advert.OwnerId).Result;
            var adv = new Advertisement { GastronomicVenue=venue, AdvertisementId = Guid.NewGuid(), Active = true, DateAdded = DateTime.Now, Description = advert.Discription, Title = advert.Title, GastronomicVenueId = advert.OwnerId,EventDate=advert.DateEvent };
            _advertisementServiecs.AddAdvert(adv);
            
            if (advert.File != null)
            {
                var fileName = Path.Combine("C:/Users/Szymon/Desktop/PubProjetPwr/PubProjectClient/wwwroot/upload/", adv.AdvertisementId.ToString());
                advert.File.CopyTo(new FileStream(fileName+".jpg", FileMode.Create));
                var f = new PubProjectApi.Models.File { OwnerId = adv.AdvertisementId, FileName = fileName, FileId = Guid.NewGuid() };
                _fileService.AddFile(f);
            }

            return Ok();

        }

        [HttpPost]
        [Route("AddLike")]
        public void AddLike([FromBody] AddLike addLike)
        {
            _likeService.AddLike(addLike);
        }
    }
}
