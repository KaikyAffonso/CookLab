using CookLab.Model;
using CookLab.Service.Ingredients;
using CookLab.Service.Measures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Measures
{
    public class UpdateModel : PageModel
    {
        private readonly IMeasureService _service;

        public Measure Measure { get; set; }
        public UpdateModel(IMeasureService service)
        {
            _service = service;
        }
        public void OnGet(int id)
        {
            Measure = _service.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Measure measure = new Measure();

            measure.Id = Convert.ToInt32(Request.Form["id"]);
            measure.Name = Convert.ToString(Request.Form["name"]);
            _service.Update(measure);

            return Redirect("/Measures/Measure");



        }
    }
}
