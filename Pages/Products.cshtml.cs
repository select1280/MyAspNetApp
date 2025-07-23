using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAspNetApp.Models;
using MyAspNetApp.Service;

namespace MyAspNetApp.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ProductService _service;

        public List<Product> ProductList { get; set; }

        public ProductsModel(ProductService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            ProductList = _service.GetAll();
        }
    }
}
