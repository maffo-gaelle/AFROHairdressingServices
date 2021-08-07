using HairDressingServices.Api.Models.Client.Repositories;
using HairDressingServices.Api.Models.Client.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFROHairdressingServices.Security.API.Models.Forms.AvisForm;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFROHairdressingServices.Security.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvisController : ControllerBase
    {
        private IAvisRepository _avisRepository;

        public AvisController(IAvisRepository avisRepository)
        {
            _avisRepository = avisRepository;
        }

        // GET: api/<AvisController>
        [HttpGet("AvisByProfessionnal/{id}")]
        public IEnumerable<Avis> GetAvis(int id)
        {
            return _avisRepository.GetAllAvisByProfessionnal(id);
        }

        // GET api/<AvisController>/5
        [HttpGet("{id}")]
        public Avis Get(int id)
        {
            return _avisRepository.Get(id);
        }

        // GET: api/<AvisController>
        [HttpGet("CommentsByAvis/{id}")]
        public IEnumerable<Comment> GetCommentsByAvis(int id)
        {
            return _avisRepository.GetAllCommentByAvis(id);
        }


        // POST api/<AvisController>
        [HttpPost]
        public void Post([FromBody] AddAvisForm form)
        {
            _avisRepository.Insert(new Avis(form.Content, form.Star, form.UserId, form.PrestationId, form.Timestamp));
        }

        // PUT api/<AvisController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UpdateAvisForm form)
        {
            _avisRepository.Update(id, new Avis(form.Content, form.Star, form.UserId, form.PrestationId, form.Timestamp ));
        }

        // DELETE api/<AvisController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
