using CookLab.Model;
using CookLab.Service.Favorites;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CookLabWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _service;
        public FavoriteController(IFavoriteService service)
        {

            _service = service;
        }
        // GET: api/<FavoriteController>
        [HttpGet]
        public IEnumerable<Favorite> Get()
        {
            return _service.RetrieveAll();
        }

        // GET api/<FavoriteController>/5
        [HttpGet("{id}")]
        public Favorite Get(int id)
        {
            return _service.Retrieve(id);
        }

        // POST api/<FavoriteController>
        [HttpPost]
        public Favorite Post([FromBody] Favorite favorite)
        {
            return _service.Create(favorite);
        }

        // PUT api/<FavoriteController>/5
        [HttpPut("{id}")]
        public Favorite Put(int id, [FromBody] Favorite favorite)
        {
           return _service.Update(favorite);  
        }

        // DELETE api/<FavoriteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);    
        }
    }
}
