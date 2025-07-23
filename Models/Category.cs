namespace MyAspNetApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // 導覽屬性（可選，方便 Entity Framework 反向查詢）
        public ICollection<Product>? Products { get; set; }
    }
}
