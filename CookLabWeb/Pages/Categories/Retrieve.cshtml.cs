using CookLab.Model;
using CookLab.Service.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Categories
{
    public class RetrieveModel : PageModel
    {
        private readonly ICategoryService _service;

        public Category Category { get; set; }

        public RetrieveModel(ICategoryService service)
        {
            _service = service;
        }

        public void OnGet(int id)
        {
            Category = _service.Retrieve(id);
        }
    }
}
