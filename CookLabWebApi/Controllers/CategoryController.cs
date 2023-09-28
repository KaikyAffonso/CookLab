using CookLab.Model;
using CookLab.Service.Categories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CookLabWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService=categoryService;
        }


        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categoryService.RetrieveAll();  
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _categoryService.Retrieve(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public Category Post([FromBody] Category category)
        {
            return _categoryService.Create(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public Category Put(int id, [FromBody] Category category)
        {
            return _categoryService.Update(category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryService.Delete(id);    
        }
    }
}
