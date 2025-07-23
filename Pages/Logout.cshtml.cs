using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyAspNetApp.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear(); // 清除所有登入資訊
            return RedirectToPage("/Login"); // 登出後回登入頁
        }
    }
}
