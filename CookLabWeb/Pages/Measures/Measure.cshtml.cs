using CookLab.Model;
using CookLab.Service.Measures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Xml.Linq;

namespace CookLabWeb.Pages.Measures
{
    public class MeasureModel : PageModel
    {

        private readonly IMeasureService _service;
        public MeasureModel(IMeasureService service)
        {
            _service = service;
        }

        public List<Measure> _measures = new List<Measure>();
        public User User { get; set; }
        public void OnGet()
        {
            GetUser();
            _measures = _service.RetrieveAll();
        }
        public void OnPost()
        {
            Measure measure = new Measure();
            measure.Name = Convert.ToString(Request.Form["name"]);
            _service.Create(measure);
            _measures = _service.RetrieveAll();
        }
        private void GetUser()
        {
            string user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                User = JsonSerializer.Deserialize<User>(user);
            }
        }
    }
}
