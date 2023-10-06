using CookLab.Model;
using CookLab.Service.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Categories
{
    public class CategoryModel : PageModel
    {
        private readonly ICategoryService _service;
        public CategoryModel(ICategoryService service)
        {
            _service = service;
        }

        public List<Category> categories { get; set; }
        public void OnGet()
        {
            categories = _service.RetrieveAll();
        }

        public void OnPost()
        {
            Category category = new Category();
            category.Name = Convert.ToString(Request.Form["name"]);
            _service.Create(category);
            categories = _service.RetrieveAll();
        }
    }
}
