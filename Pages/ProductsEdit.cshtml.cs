using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAspNetApp.Models;
using MyAspNetApp.Service;

namespace MyAspNetApp.Pages
{
    public class ProductsEditModel : PageModel
    {
        private readonly ProductService _service;

        public ProductsEditModel(ProductService service)
        {
            _service = service;
        }

        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnGet(int id)
        {
            var item = _service.GetById(id);
            if (item == null) return RedirectToPage("/Products");

            Product = new Product
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price
            };
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _service.Update(Product);
            return RedirectToPage("/Products");
        }
    }
}
