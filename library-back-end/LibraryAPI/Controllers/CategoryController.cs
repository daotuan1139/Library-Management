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
        public IActionResult GetCategories()
        {
            var categoryList = _categoryService.GetCategories();
            if (categoryList == null)
            {
                return BadRequest("Error Loading");
            }
            return Ok(categoryList);
        }

        [HttpPost("Category")]
        public IActionResult CreateCategory(Category category)
        {
            if (!ModelState.IsValid) return BadRequest("Error: Model Invalid");

            var createCategory = _categoryService.CreateCategory(category);

            if (createCategory != null)
            {

                return Ok(createCategory);
            }
            return BadRequest("Error creating category");
        }

        [HttpPut("Category")]
        public IActionResult EditCategory(Category category)
        {
            if (!ModelState.IsValid) return BadRequest("Error: Model Invalid");

            var editCategory = _categoryService.EditCategory(category);

            if (editCategory != null)
            {

                return Ok(editCategory);
            }
            return BadRequest("Error editing category");
        }

        [HttpGet("Category/{id}")]
        public IActionResult FindByID(int id)
        {
            var category = _categoryService.FindByID(id);
            if (category != null)
            {
                return BadRequest("Not Found :" + id);
            }
            return Ok(category);
        }

        [HttpDelete("Category")]
        public IActionResult DeleteCategory(Category category)
        {
            if (!ModelState.IsValid) return BadRequest("Error: Model Invalid");

            var deleteCategory = _categoryService.DeleteCategory(category);

            if (deleteCategory != null)
            {

                return Ok(deleteCategory);
            }
            return BadRequest("Error deleting category");


        }

    }
}
