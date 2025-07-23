using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAspNetApp.Models;
using MyAspNetApp.Service;

namespace MyAspNetApp.Pages
{
    public class ProductsEditModel : PageModel
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

        public ProductsEditModel(ProductService productService, CategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [BindProperty]
        public Product Product { get; set; }

        public List<Category> CategoryList { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var item = _productService.GetById(id);
            if (item == null) return RedirectToPage("/Products");

            Product = new Product
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CategoryId = item.CategoryId
            };

            CategoryList = _categoryService.GetAll(); // ← 載入分類
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                CategoryList = _categoryService.GetAll(); // ← Post 失敗時仍需載入分類
                return Page();
            }

            _productService.Update(Product);
            return RedirectToPage("/Products");
        }
    }
}
