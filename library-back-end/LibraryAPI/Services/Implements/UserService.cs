using System;
using System.Collections.Generic;
using System.Linq;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using static LibraryAPI.Services.ILibraryService;

namespace LibraryAPI.Services
{

    public class UserService : IUserService
    {
        private LibraryContext _libraryContext;
        public UserService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        //CRUD
        public IEnumerable<User> GetUsers()
        {
            return _libraryContext.Users.ToList();
        }
    }

}