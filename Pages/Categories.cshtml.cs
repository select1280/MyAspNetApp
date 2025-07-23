using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAspNetApp.Models;
using MyAspNetApp.Service;

namespace MyAspNetApp.Pages
{
    public class CategoriesModel : PageModel
    {
        private readonly CategoryService _service;

        public List<Category> CategoryList { get; set; }

        public CategoriesModel(CategoryService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToPage("/Login");
            }

            CategoryList = _service.GetAll();
            return Page();
        }
    }
}
