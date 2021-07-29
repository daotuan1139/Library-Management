using System;
using System.Collections.Generic;
using System.Linq;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using static LibraryAPI.Services.ILibraryService;

namespace LibraryAPI.Services
{

    public class BookBorrowingRequestService : IBookBorrowingRequestService
    {
        private LibraryContext _libraryContext;
        public BookBorrowingRequestService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public BookBorrowingRequest CreateRequest(BookBorrowingRequestDTO request)
        {
            using var transaction = _libraryContext.Database.BeginTransaction();
            try
            {
                var newRequest = new BookBorrowingRequest
                {
                    UserID = request.UserID,
                    AdminApproved = request.AdminApproved,
                    DateRequest = request.DateRequest,
                    Status = request.Status,
                };
                _libraryContext.BookBorrowingRequests.Add(newRequest);
                _libraryContext.SaveChanges();
                transaction.Commit();
                
                return newRequest;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //CRUD
        public List<BookBorrowingRequest> EditBookBorrowingRequest(BookBorrowingRequestDTO request)
        {
            using var transaction = _libraryContext.Database.BeginTransaction();
            
            try
            {
                var existingResquest = _libraryContext.BookBorrowingRequests.Find(request.BookBorrowingRequestID);

                if (existingResquest == null)
                {
                    return null;
                }
                else
                {
                    existingResquest.Status = request.Status;
                    existingResquest.AdminApproved = request.AdminApproved;

                    _libraryContext.Entry(existingResquest).State = EntityState.Modified;
                    _libraryContext.SaveChanges();
                    transaction.Commit();
                }
                return _libraryContext.BookBorrowingRequests.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public BookBorrowingRequest FindByID(int id)
        {
            var existingResquest = _libraryContext.BookBorrowingRequests.Find(id);

            return existingResquest;
        }

        public IEnumerable<BookBorrowingRequest> GetBookBorrowingRequest()
        {
            return _libraryContext.BookBorrowingRequests.ToList();
        }

    }

}