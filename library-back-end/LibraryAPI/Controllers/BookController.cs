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
        private IUserService _userService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService,IUserService userService ,ILogger<BookController> logger)
        {
            _bookService = bookService;
            _userService = userService;
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
                    if (book != null)
                    {
                        _bookService.CreateBook(book);
                        return Ok(book);
                    }
                    return BadRequest("Error adding book");
                }
                else
                {
                    return StatusCode(403);
                }
            }
        }

        [HttpPut("Book")]
        public IActionResult UpdateBook(BookDTO book)
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
                    if (book != null)
                    {
                        _bookService.EditBook(book);
                        return Ok(book);
                    }
                    return BadRequest("Error editing book");
                }
                else
                {
                    return StatusCode(403);
                }
            }
        }

        [HttpGet("Book/{id}")]
        public IActionResult FindByIDBook(int id)
        {
            var book = _bookService.FindByID(id);
            if (book != null)
            {
                return BadRequest("Not Found :" + id);
            }
            return Ok(book);
        }

        [HttpDelete("Book")]
        public IActionResult DeleteBook(BookDTO book)
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
                    if (book != null)
                    {
                        _bookService.EditBook(book);
                        return Ok(book);
                    }
                    return BadRequest("Error deleting book");
                }
                else
                {
                    return StatusCode(403);
                }
            }
        }
        
    }
}
