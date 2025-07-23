using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAspNetApp.Models;
using MyAspNetApp.Service;
using System.IO;
using Microsoft.AspNetCore.Http;

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

        public async Task<IActionResult> OnPostAsync(IFormFile? photo)
        {
            CategoryList = _categoryService.GetAll();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (photo != null)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }

                Product.ImageName = fileName;
            }

            _productService.Add(Product);
            return RedirectToPage("/Products");
        }
    }
}
