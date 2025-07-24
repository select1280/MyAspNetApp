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
                CategoryId = item.CategoryId,
                ImageName = item.ImageName
            };

            CategoryList = _categoryService.GetAll(); // ← 載入分類
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile? photo)
        {
            if (!ModelState.IsValid) return Page();

            // 原始資料（從 DB 查）
            var existing = _productService.GetById(Product.Id);
            if (existing == null) return RedirectToPage("/Products");

            // 如果有新圖片
            if (photo != null)
            {
                // 刪除舊圖
                if (!string.IsNullOrEmpty(Product.ImageName))
                {
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", Product.ImageName);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }

                // 儲存新圖
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }
                // 沒上傳圖片 → 保留舊圖
                existing.ImageName = fileName;
            }

            //更新 existing 實體上的屬性（EF 正在追蹤）
            existing.Name = Product.Name;
            existing.Price = Product.Price;
            existing.CategoryId = Product.CategoryId;
            existing.ImageName = Product.ImageName;

            //儲存
            _productService.Save(); // 改名為 Save() 或 SaveChanges()
            return RedirectToPage("/Products");
        }


    }
}
