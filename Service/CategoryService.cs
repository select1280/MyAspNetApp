using System.Collections.Generic;
using System.Linq;
using MyAspNetApp.Data;
using MyAspNetApp.Models;

namespace MyAspNetApp.Service
{
    public class CategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        // 新增分類
        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        // 取得所有分類
        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        internal void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Category? GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

    }
}
