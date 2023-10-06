using CookLab.Model;
using CookLab.Service.Measures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public void OnGet()
        {
            _measures = _service.RetrieveAll();
        }
        public void OnPost()
        {
            Measure measure = new Measure();
            measure.Name = Convert.ToString(Request.Form["name"]);
            _service.Create(measure);
            _measures = _service.RetrieveAll();
        }
    }
}
