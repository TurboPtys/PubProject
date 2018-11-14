using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PubProjectApi.Servies;

namespace PubProjectApi.Controllers
{
    [Produces("application/json")]
    [Route("api/GastronomicVenue")]
    public class GastronomicVenueController : Controller
    {

        private readonly IGastronomicVenuesService _gastronomicVenuesService;

        public GastronomicVenueController(IGastronomicVenuesService gastronomicVenuesService)
        {
            _gastronomicVenuesService = gastronomicVenuesService;
        }

        // GET: api/GastronomicVenue
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var gastronomicVenues = await _gastronomicVenuesService.GetAll();
            return Ok(gastronomicVenues);
        }
    }
}