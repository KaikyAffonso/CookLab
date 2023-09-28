using CookLab.Model;
using CookLab.Service.Measures;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CookLabWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasureController : ControllerBase
    {
        private readonly IMeasureService _service;
        public MeasureController(IMeasureService service)
        {
            _service=service;
        }

        // GET: api/<MeasureController>
        [HttpGet]
        public IEnumerable<Measure> Get()
        {
            return _service.RetrieveAll();
        }

        // GET api/<MeasureController>/5
        [HttpGet("{id}")]
        public Measure Get(int id)
        {
            return _service.Retrieve(id);
        }

        // POST api/<MeasureController>
        [HttpPost]
        public Measure Post([FromBody] Measure measure)
        {
            return _service.Create(measure);
        }

        // PUT api/<MeasureController>/5
        [HttpPut("{id}")]
        public Measure Put(int id, [FromBody] Measure measure)
        {
            return _service.Update(measure);
        }

        // DELETE api/<MeasureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
