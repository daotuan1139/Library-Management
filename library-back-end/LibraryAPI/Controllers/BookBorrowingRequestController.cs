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
        private readonly ILogger<BookBorrowingRequestController> _logger;

        public BookBorrowingRequestController(IBookBorrowingRequestService requestService, ILogger<BookBorrowingRequestController> logger)
        {
            _requestService = requestService;
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

        [HttpPost("Request")]
        public IActionResult CreateRequest(BookBorrowingRequestDTO request)
        {
            if (!ModelState.IsValid) return BadRequest("Error: Model Invalid");

            var createRequest = _requestService.CreateRequest(request);

            if (createRequest != null)
            {
                return Ok(createRequest);
            }
            return BadRequest("Error creating request");

        }

        [HttpPut("Request")]
        public IActionResult UpdateRequest(BookBorrowingRequestDTO request)
        {
            if (!ModelState.IsValid) return BadRequest("Error: Model Invalid");

            var editRequest = _requestService.EditBookBorrowingRequest(request);

            if (editRequest != null)
            {
                return Ok(editRequest);
            }
            return BadRequest("Error editing request");

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
