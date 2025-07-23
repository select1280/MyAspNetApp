using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAspNetApp.Models;
using MyAspNetApp.Service;

namespace MyAspNetApp.Pages
{
    public class ProductsCreateModel : PageModel
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

        public ProductsCreateModel(ProductService productService, CategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [BindProperty]
        public Product Product { get; set; }

        public List<Category> CategoryList { get; set; } = new();

        public void OnGet()
        {
            CategoryList = _categoryService.GetAll();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                CategoryList = _categoryService.GetAll(); // 若錯誤需再帶一次分類資料
                return Page();
            }

            _productService.Add(Product);
            return RedirectToPage("/Products");
        }
    }
}
