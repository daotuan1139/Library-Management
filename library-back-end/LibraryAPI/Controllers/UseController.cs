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
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("User")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers().ToList();

            if (users != null)
            {
                return Ok(users);
            }
            return BadRequest("Error Loading");
        }

        [HttpPost("Login")]
        public IActionResult Login(User user)
        {
            var userLogin = _userService.GetUsers().SingleOrDefault(u => u.UserEmail == user.UserEmail && u.UserPassword == user.UserPassword);
            Response.Headers.Add("token", "token");
            if (userLogin != null)
            {

                return Ok(userLogin);
            }

            return BadRequest("Wrong user name or password");
        }

        [HttpGet("User/{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.FindByID(id);
            if (user == null)
            {
                return BadRequest("Not Found :" + id);
            }
            return Ok(user);
        }

    }
}
