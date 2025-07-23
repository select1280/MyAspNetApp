using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAspNetApp.Models;
using MyAspNetApp.Service;

namespace MyAspNetApp.Pages
{
    public class CategoriesEditModel : PageModel
    {
        private readonly CategoryService _categoryService;

        public CategoriesEditModel(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public Category Category { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var item = _categoryService.GetById(id);
            if (item == null) return RedirectToPage("/Categories");

            Category = new Category
            {
                Id = item.Id,
                Name = item.Name
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _categoryService.Update(Category);
            return RedirectToPage("/Categories");
        }
    }
}
