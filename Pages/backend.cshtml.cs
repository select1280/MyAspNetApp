using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyAspNetApp.Pages
{
    public class BackendModel : PageModel
    {
        public string? Username { get; set; }

        public IActionResult OnGet()
        {
            var user = HttpContext.Session.GetString("User");

            if (string.IsNullOrEmpty(user))
            {
                return RedirectToPage("/Login");    // 沒登入跳回登入
            }

            Username = user;
            return Page();  // 成功登入顯示後台
        }
    }
}
