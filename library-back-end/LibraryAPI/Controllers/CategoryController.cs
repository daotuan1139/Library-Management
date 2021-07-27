using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static LibraryAPI.Services.ILibraryService;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class CategoryController : ControllerBase
    {

        private ICategoryService _categoryService;

        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet("Category")]
        public IEnumerable<Category> GetCategories()
        {
            return _categoryService.GetCategories();
        }

        [HttpPost("Category")]
        public IActionResult AddAuthor(Category category)
        {
            var add = _categoryService.CreateCategory(category);
            if (add == null)
            {
                return NotFound();
            }
            return Ok(add);
        }

        [HttpPut("Category")]
        public List<Category> UpdateAuthor(Category category)
        {
            var update = _categoryService.EditCategory(category);
            return update;
        }

        [HttpGet("Category/{id}")]
        public Category FindByIDAuthor(int id)
        {
            return _categoryService.FindByID(id);
        }

        [HttpDelete("Category")]
        public List<Category> IsDeleteAuthor(Category category)
        {
            var list = _categoryService.DeleteCategory(category);
            return list;
        }
        
    }
}
