using HairDressingServices.Api.Models.Client.Data;
using HairDressingServices.Api.Models.Client.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFROHairdressingServices.Security.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalityController : ControllerBase
    {
        private readonly ILocalityRepository _localityRepository;

        public LocalityController(ILocalityRepository localityRepository)
        {
            _localityRepository = localityRepository;
        }

        // GET: api/<LocalityController>
        [HttpGet]
        public IEnumerable<Locality> Get()
        {
            return _localityRepository.Get();
        }

        // GET api/<LocalityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LocalityController>
        [HttpPost]
        public void Post(Locality locality)
        {
            if (!_localityRepository.ExistsLocality(locality))
                _localityRepository.Add(locality);
        }

        // PUT api/<LocalityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocalityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
