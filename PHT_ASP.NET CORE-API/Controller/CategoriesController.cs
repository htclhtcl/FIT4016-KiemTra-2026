using Microsoft.AspNetCore.Mvc;
using CategoryAPI.Models;
using CategoryAPI.Services;

namespace CategoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<Category>> GetAll() => Ok(_categoryService.GetAllCategories());

        [HttpGet("{id}")]
        public ActionResult<Category> GetById(int id)
        {
            var cat = _categoryService.GetCategoryById(id);
            return cat == null ? NotFound() : Ok(cat);
        }

        [HttpPost]
        public ActionResult<Category> Create(Category category)
        {
            var newCat = _categoryService.CreateCategory(category);
            return CreatedAtAction(nameof(GetById), new { id = newCat.Id }, newCat);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Category category)
        {
            var updated = _categoryService.UpdateCategory(id, category);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _categoryService.DeleteCategory(id) ? NoContent() : NotFound();
        }
    }
}