namespace MyAspNetApp.Models
{
    public class User
    {
        public int Id { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; } // 實務中會加密，這裡簡化用明碼
    }
}
