using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyAspNetApp.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost(string account, string password)
        {
            if (account == "admin" && password == "1234")
            {
                HttpContext.Session.SetString("User", account); // 記住登入帳號
                return RedirectToPage("/Backend");              // 登入成功導向後台
            }
            else
            {
                ModelState.AddModelError(string.Empty, "帳號或密碼錯誤");
                return Page(); // 留在登入頁顯示錯誤
            }
        }
    }
}
