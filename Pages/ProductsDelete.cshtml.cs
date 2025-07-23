using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAspNetApp.Service;

namespace MyAspNetApp.Pages
{
    public class ProductsDeleteModel : PageModel
    {
        private readonly ProductService _service;

        public ProductsDeleteModel(ProductService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int id)
        {
            _service.Delete(id);        //用注入的物件來呼叫方法
            return RedirectToPage("/Products");
        }
    }
}
