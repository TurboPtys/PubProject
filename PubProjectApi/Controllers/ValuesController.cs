using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PubProjectApi.Models;
using PubProjectApi.Repository.Interface;

namespace PubProjectApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly IGastronomicVenuesRepository _gastronomicVenuesRepository;

        public ValuesController(IGastronomicVenuesRepository gastronomicVenuesRepository) => _gastronomicVenuesRepository = gastronomicVenuesRepository;

        [HttpGet]
        public IActionResult Get()
        {
            var bars = _gastronomicVenuesRepository.GetAll();
            return Ok(bars);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid? id)
        {
            var bar = _gastronomicVenuesRepository.GetById(id);
            return Ok(bar);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
