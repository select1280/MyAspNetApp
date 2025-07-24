using MyAspNetApp.Models;
using MyAspNetApp.Data;
using Microsoft.EntityFrameworkCore;

namespace MyAspNetApp.Service
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
        public void Save()
        {
            _context.SaveChanges(); // 已追蹤的物件就會自動更新
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.Products.Remove(item);
                _context.SaveChanges();
            }
        }
        public List<Product> GetAllWithCategory()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

       
    }
}
