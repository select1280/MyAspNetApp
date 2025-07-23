using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAspNetApp.Models;
using MyAspNetApp.Service;

namespace MyAspNetApp.Pages
{
    public class ProductsCreateModel : PageModel
    {
        private readonly ProductService _service;

        public ProductsCreateModel(ProductService service)
        {
            _service = service;
        }

        [BindProperty]
        public required Product Product { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _service.Add(Product);      //使用物件呼叫
            return RedirectToPage("/Products");
        }
    }
}
