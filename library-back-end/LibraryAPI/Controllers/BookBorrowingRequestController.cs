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
    public class BookBorrowingRequestController : ControllerBase
    {
        private IBookBorrowingRequestService _requestService;
        private IUserService _userService;
        private readonly ILogger<BookBorrowingRequestController> _logger;

        public BookBorrowingRequestController(IBookBorrowingRequestService requestService,IUserService userService, ILogger<BookBorrowingRequestController> logger)
        {
            _requestService = requestService;
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("Request")]
        public IActionResult GetRequests()
        {
            var requestList = _requestService.GetBookBorrowingRequest();
            if (requestList == null)
            {
                return BadRequest("Error Loading");
            }
            return Ok(requestList);
        }

        [HttpPut("Request")]
        public IActionResult UpdateRequest(BookBorrowingRequestDTO request)
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
                    if (request != null)
                    {
                        _requestService.EditBookBorrowingRequest(request);
                        return Ok(request);
                    }
                    return BadRequest("Error editing request");
                }
                else
                {
                    return StatusCode(403);
                }
            }
        }

        [HttpGet("Request/{id}")]
        public IActionResult FindByID(int id)
        {
            var request = _requestService.FindByID(id);
            if (request != null)
            {
                return BadRequest("Not Found :" + id);
            }
            return Ok(request);
        }

    }
}
