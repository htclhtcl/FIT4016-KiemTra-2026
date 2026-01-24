using CategoryAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace CategoryAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Books" },
            new Category { Id = 3, Name = "Clothing" }
        };

        public List<Category> GetAllCategories() => _categories;

        public Category? GetCategoryById(int id) => _categories.FirstOrDefault(c => c.Id == id);

        public Category CreateCategory(Category category)
        {
            category.Id = _categories.Any() ? _categories.Max(c => c.Id) + 1 : 1;
            _categories.Add(category);
            return category;
        }

        public Category? UpdateCategory(int id, Category category)
        {
            var existing = GetCategoryById(id);
            if (existing == null) return null;
            existing.Name = category.Name;
            existing.Description = category.Description;
            return existing;
        }

        public bool DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category == null) return false;
            _categories.Remove(category);
            return true;
        }
    }
}