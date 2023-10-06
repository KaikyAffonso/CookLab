using CookLab.Model;
using CookLab.Service.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryService _service;

        public DeleteModel(ICategoryService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int id)
        {
            _service.Delete(id);
            return Redirect("/Categories/Category");
        }
    }
}
