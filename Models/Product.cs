using System.ComponentModel.DataAnnotations.Schema;

namespace MyAspNetApp.Models
{
    public class Product
    {
        public int Id { get; set; } // 商品 ID
        public string? Name { get; set; } // 商品名稱
        public decimal Price { get; set; } // 價格
        public string? ImageName { get; set; } // 可為 null 的圖片檔名

        public int CategoryId { get; set; }// 外鍵
         [ForeignKey("CategoryId")]
        public Category? Category { get; set; }// 導覽屬性
    }
}
