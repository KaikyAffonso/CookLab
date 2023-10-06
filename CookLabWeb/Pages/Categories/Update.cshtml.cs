using CookLab.Model;
using CookLab.Service.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Categories
{
    public class UpdateModel : PageModel
    {
        private readonly ICategoryService _service;

        public Category Category { get; set; }
        public UpdateModel(ICategoryService service)
        {
            _service = service;
        }
        public void OnGet(int id)
        {
            Category = _service.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Category category = new Category();
       
            category.Id = Convert.ToInt32(Request.Form["id"]);
            category.Name = Convert.ToString(Request.Form["name"]);
            _service.Update(category);

            return Redirect("/Categories/Category");



        }
    }
}
