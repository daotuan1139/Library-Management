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
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private IBookService _bookService;
        private ICategoryService _categoryService;

        private readonly ILogger<LibraryController> _logger;

        public LibraryController(IBookService bookService, ICategoryService categoryService, ILogger<LibraryController> logger)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet("Book")]
        public IEnumerable<Book> GetBooks()
        {
            return _bookService.GetList();
        }
        [HttpGet("Category")]
        public IEnumerable<Category> GetCategories()
        {
            return _categoryService.GetCategories();
        }

        [HttpPost("Book")]
        public IActionResult AddBook(Book Book)
        {
            var add = _bookService.CreateBook(Book);
            if (add == null)
            {
                return NotFound();
            }
            return Ok(add);
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

        [HttpPut("Book")]
        public List<Book> UpdateBook(Book Book)
        {
            var update = _bookService.EditBook(Book);
            return update;
        }
        [HttpPut("Category")]
        public List<Category> UpdateAuthor(Category category)
        {
            var update = _categoryService.EditCategory(category);
            return update;
        }

        [HttpGet("Book/{id}")]
        public Book FindByIDBook(int id)
        {
            return _bookService.FindByID(id);
        }

        [HttpGet("Category/{id}")]
        public Category FindByIDAuthor(int id)
        {
            return _categoryService.FindByID(id);
        }

        [HttpDelete("Book")]
        public List<Book> IsDeleteBook(Book book)
        {
            var list = _bookService.IsDelete(book);
            return list;
        }

        [HttpDelete("Category")]
        public List<Category> IsDeleteAuthor(Category category)
        {
            var list = _categoryService.IsDelete(category);
            return list;
        }
        
    }
}
