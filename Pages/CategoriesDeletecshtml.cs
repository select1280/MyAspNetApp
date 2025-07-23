using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAspNetApp.Service;

namespace MyAspNetApp.Pages
{
    public class CategoriesDeleteModel : PageModel
    {
        private readonly CategoryService _categoryService;

        public CategoriesDeleteModel(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult OnGet(int id)
        {
            _categoryService.Delete(id);
            return RedirectToPage("/Categories");
        }
    }
}
