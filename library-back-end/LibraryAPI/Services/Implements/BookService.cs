using System;
using System.Collections.Generic;
using System.Linq;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using static LibraryAPI.Services.ILibraryService;

namespace LibraryAPI.Services
{

    public class BookService : IBookService
    {
        private LibraryContext _libraryContext;
        public BookService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        //CRUD

        public IEnumerable<Book> GetList()
        {
            return _libraryContext.Books.ToList();
        }
        public Book CreateBook(BookDTO book)
        {
            using var transaction = _libraryContext.Database.BeginTransaction();
            try
            {
                var newBook = new Book
                {
                    BookName = book.BookName,
                };
                _libraryContext.Books.Add(newBook);
                _libraryContext.SaveChanges();
                transaction.Commit();
                
                return newBook;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<Book> EditBook(BookDTO book)
        {
            using var transaction = _libraryContext.Database.BeginTransaction();
            try
            {
                var existingBook = _libraryContext.Books.Find(book.BookID);

                if (existingBook == null)
                {
                    return null;
                }
                else
                {
                    existingBook.BookName = book.BookName;

                    _libraryContext.Entry(existingBook).State = EntityState.Modified;
                    _libraryContext.SaveChanges();
                    transaction.Commit();
                }
                return _libraryContext.Books.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public Book FindByID(int id)
        {
            var existingBook = _libraryContext.Books.Find(id);

            return existingBook;
        }

        public List<Book> DeleteBook(BookDTO book)
        {
            using var transaction = _libraryContext.Database.BeginTransaction();
            try
            {
                var existingBook = _libraryContext.Books.Find(book.BookID);
                if (existingBook != null)
                {
                    _libraryContext.Remove(existingBook);
                    _libraryContext.SaveChanges();
                    transaction.Commit();
                    return _libraryContext.Books.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }
    }

}