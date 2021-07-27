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
    public class BookController : ControllerBase
    {
        private IBookService _bookService;

        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet("Book")]
        public IEnumerable<Book> GetBooks()
        {
            return _bookService.GetList();
        }

        [HttpPost("Book")]
        public IActionResult AddBook(BookDTO Book)
        {
            var add = _bookService.CreateBook(Book);
            if (add == null)
            {
                return NotFound();
            }
            return Ok(add);
        }

        [HttpPut("Book")]
        public List<Book> UpdateBook(BookDTO Book)
        {
            var update = _bookService.EditBook(Book);
            return update;
        }

        [HttpGet("Book/{id}")]
        public Book FindByIDBook(int id)
        {
            return _bookService.FindByID(id);
        }

        [HttpDelete("Book")]
        public List<Book> IsDeleteBook(BookDTO book)
        {
            var list = _bookService.DeleteBook(book);
            return list;
        }
        
    }
}
