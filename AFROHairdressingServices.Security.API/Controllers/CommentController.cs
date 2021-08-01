using HairDressingServices.Api.Models.Client.Repositories;
using HairDressingServices.Api.Models.Client.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFROHairdressingServices.Security.API.Models.Forms.CommentForm;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFROHairdressingServices.Security.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        // GET: api/<CommentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public Comment Get(int id)
        {
            return _commentRepository.Get(id);
        }

        // POST api/<CommentController>
        [HttpPost]
        public void Post([FromBody] AddCommentForm form)
        {
            _commentRepository.Insert(new Comment(form.Content, form.AvisId, form.UserId, form.Timestamp));
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EditCommentForm form)
        {
            _commentRepository.Update(id, new Comment(form.Content, form.IdAvis, form.UserId,  form.Timestamp));
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //_commentRepository.Delete(id)
        }
    }
}
