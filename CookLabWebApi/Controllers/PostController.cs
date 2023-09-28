using CookLab.Model;
using CookLab.Service.Posts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CookLabWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;
        public PostController(IPostService service)
        {
            _service=service;
        }
    

        // GET: api/<PostController>
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _service.RetrieveAll();
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public Post Get(int id)
        {
            return _service.Retrieve(id);
        }

        // POST api/<PostController>
        [HttpPost]
        public Post Post([FromBody] Post post)
        {
           return  _service.Create(post);
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public Post Put(int id, [FromBody] Post post)
        {
         return  _service.Update(post);
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
