using CookLab.Service.Ingredients;
using CookLab.Service.Measures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Measures
{
    public class DeleteModel : PageModel
    {
        private readonly IMeasureService _service;

        public DeleteModel(IMeasureService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int id)
        {
            _service.Delete(id);
            return Redirect("/Measures/Measure");
        }
    }
}
