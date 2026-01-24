using CategoryAPI.Models;
using System.Collections.Generic;

namespace CategoryAPI.Services
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category? GetCategoryById(int id);
        Category CreateCategory(Category category);
        Category? UpdateCategory(int id, Category category);
        bool DeleteCategory(int id);
    }
}