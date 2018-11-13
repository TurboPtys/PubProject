using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PubProjectApi.Repository.Interface;
using PubProjectApi.Servies;

namespace PubProjectApi.Controllers
{
    [Route("api/Advertisement")]
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementService _advertisementServiecs;
        
        public AdvertisementController(IAdvertisementService advertisementService)
        {
            _advertisementServiecs = advertisementService;
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
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Advertisement/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
