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
        public IActionResult GetBooks()
        {
            var bookList = _bookService.GetList();
            if (bookList == null)
            {
                return BadRequest("Error Loading");
            }
            return Ok(bookList);
        }


        [HttpPost("Book")]
        public IActionResult AddBook(BookDTO book)
        {
            if (!ModelState.IsValid) return BadRequest("Error: Model Invalid");

            var addBook = _bookService.CreateBook(book);
            if (addBook != null)
            {
                return Ok(addBook);
            }
            return BadRequest("Error adding book");

        }

        [HttpPut("Book")]
        public IActionResult UpdateBook(BookDTO book)
        {
            if (!ModelState.IsValid) return BadRequest("Error: Model Invalid");

            var editBook = _bookService.EditBook(book);
            if (editBook != null)
            {
                return Ok(editBook);
            }
            return BadRequest("Error adding book");
        }

        [HttpGet("Book/{id}")]
        public IActionResult FindByIDBook(int id)
        {
            var book = _bookService.FindByID(id);
            if (book == null)
            {
                return BadRequest("Not Found :" + id);
            }
            return Ok(book);
        }

        [HttpDelete("Book")]
        public IActionResult DeleteBook(BookDTO book)
        {
            var deleteBook = _bookService.DeleteBook(book);
            if (deleteBook == null)
            {
                return BadRequest("Error deleting book" );
            }
            return Ok(deleteBook);
        }

    }
}
