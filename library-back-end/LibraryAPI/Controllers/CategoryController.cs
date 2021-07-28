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
        private IUserService _userService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, IUserService userService ,ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _userService = userService;
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

            string token = Request.Headers["token"];
            if (token == null)
            {
                return Unauthorized();
            }
             else
            {
                var user = _userService.GetUsers().SingleOrDefault(u => u.UserID == int.Parse(token));
                if (user.RoleAdmin == true)
                {
                    if (category != null)
                    {
                        _categoryService.CreateCategory(category);
                        return Ok(category);
                    }
                    return BadRequest("Error adding category");
                }
                else
                {
                    return StatusCode(403);
                }
            };
        }

        [HttpPut("Category")]
        public IActionResult EditCategory(Category category)
        {
            if (!ModelState.IsValid) return BadRequest("Error: Model Invalid");

            string token = Request.Headers["token"];
            if (token == null)
            {
                return Unauthorized();
            }
             else
            {
                var user = _userService.GetUsers().SingleOrDefault(u => u.UserID == int.Parse(token));
                if (user.RoleAdmin == true)
                {
                    if (category != null)
                    {
                        _categoryService.EditCategory(category);
                        return Ok(category);
                    }
                    return BadRequest("Error editing category");
                }
                else
                {
                    return StatusCode(403);
                }
            }
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

            string token = Request.Headers["token"];
            if (token == null)
            {
                return Unauthorized();
            }
             else
            {
                var user = _userService.GetUsers().SingleOrDefault(u => u.UserID == int.Parse(token));
                if (user.RoleAdmin == true)
                {
                    if (category != null)
                    {
                        _categoryService.DeleteCategory(category);
                        return Ok(category);
                    }
                    return BadRequest("Error deleting category");
                }
                else
                {
                    return StatusCode(403);
                }
            }
        }
        
    }
}
