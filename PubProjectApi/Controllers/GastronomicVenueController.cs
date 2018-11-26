using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PubProjectApi.Models;
using PubProjectApi.Models.ModelsView;
using PubProjectApi.Servies;

namespace PubProjectApi.Controllers
{
    [Produces("application/json")]
    [Route("api/GastronomicVenue")]
    public class GastronomicVenueController : Controller
    {

        private readonly IGastronomicVenuesService _gastronomicVenuesService;
        private readonly IAdvertisementService _advertisementService;

        public GastronomicVenueController(IGastronomicVenuesService gastronomicVenuesService, IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
            _gastronomicVenuesService = gastronomicVenuesService;
        }

        // GET: api/GastronomicVenue
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var gastronomicVenues = await _gastronomicVenuesService.GetAll();
            return Ok(gastronomicVenues);
        }

        // GET api/GastronomicVenue/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var gastronomicVenue = await _gastronomicVenuesService.GetById(id);
            var advertisements = await _advertisementService.GetByVenue(id);
            double star = 4.75;

            var model = new GastronomicVenueView {Advertisements = advertisements, GastronomicVenue = gastronomicVenue, Grade = star };
            return Ok(model);
        }


        [HttpPost]
        public void Post([FromBody] GastronomicVenue venue)
        {
            _gastronomicVenuesService.AddVenue(venue);
        }
    }
}