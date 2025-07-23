using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAspNetApp.Models;
using MyAspNetApp.Service;

namespace MyAspNetApp.Pages
{
    public class CategoriesCreateModel : PageModel
    {
        private readonly CategoryService _service;

        [BindProperty]
        public Category Category { get; set; }

        public CategoriesCreateModel(CategoryService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            // 檢查是否登入
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToPage("/Login");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Create(Category);
            return RedirectToPage("/Categories");
        }
    }
}
