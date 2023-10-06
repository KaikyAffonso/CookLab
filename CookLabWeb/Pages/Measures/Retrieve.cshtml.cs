using CookLab.Model;
using CookLab.Service.Ingredients;
using CookLab.Service.Measures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Measures
{
    public class RetrieveModel : PageModel
    {
        private readonly IMeasureService _service;

        public Measure Measure { get; set; }

        public RetrieveModel(IMeasureService service)
        {
            _service = service;
        }

        public void OnGet(int id)
        {
            Measure = _service.Retrieve(id);
        }
    }
}
