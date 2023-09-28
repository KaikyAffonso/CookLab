using CookLab.Model;
using CookLab.Service.Difficulties;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CookLabWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyController : ControllerBase
    {
        private readonly IDifficultyService _service;

        public DifficultyController(IDifficultyService service)
        {
            _service = service;
        }
        // GET: api/<DifficultyController>
        [HttpGet]
        public IEnumerable<Difficulty> Get()
        {
            return _service.RetrieveAll();
        }

        // GET api/<DifficultyController>/5
        [HttpGet("{id}")]
        public Difficulty Get(int id)
        {
            return _service.Retrieve(id);
        }

        // POST api/<DifficultyController>
        [HttpPost]
        public Difficulty Post([FromBody] Difficulty difficulty)
        {
            return _service.Create(difficulty);
        }

        // PUT api/<DifficultyController>/5
        [HttpPut("{id}")]
        public Difficulty Put(int id, [FromBody] Difficulty difficulty)
        {
            return _service.Update(difficulty);
        }

        // DELETE api/<DifficultyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
