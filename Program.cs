using Microsoft.EntityFrameworkCore;
using MyAspNetApp.Data;
using MyAspNetApp.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(); // 加入 Razor Pages 功能
builder.Services.AddSession();    // 加入 Session 服務
builder.Services.AddScoped<ProductService>();

// 加入 SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Data/app.db")); // ← 確認這裡路徑一致！

// 加入 Service
builder.Services.AddScoped<ProductService>();

builder.Services.AddRazorPages();


var app = builder.Build();

// ↓ 下面是中介軟體（Middleware）設定：
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); // 錯誤頁面
    app.UseHsts(); // 強化 HTTPS 安全
}

app.UseHttpsRedirection(); // 自動轉 https
app.UseStaticFiles();      // 讀取 wwwroot 中的靜態檔案（如 CSS、JS、圖片）
app.UseRouting();          // 啟用路由功能
app.UseSession();          // 啟用 Session
app.UseAuthorization();    // 啟用授權（若有設定）

app.MapRazorPages(); // 對應 Razor Pages 頁面（在 Pages/ 資料夾內）

app.Run(); // 啟動伺服器


