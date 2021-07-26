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

        public Book CreateBook(Book book)
        {
            var newBook = new Book
                {
                    BookName = book.BookName,
                };
            _libraryContext.Books.Add(newBook);
            _libraryContext.SaveChanges();

            return newBook;
        }

        public List<Book> EditBook(Book book)
        {
            Book existingBook = _libraryContext.Books.Find(book.BookID);

            if (existingBook == null)
            {
                return new List<Book>();
            }
            else
            {
                existingBook.BookName = book.BookName;

                _libraryContext.Entry(existingBook).State = EntityState.Modified;
                _libraryContext.SaveChanges();
            }
            return _libraryContext.Books.ToList();
        }

        public Book FindByID(int id)
        {
            Book existingBook = _libraryContext.Books.Find(id);

            return existingBook;
        }

        public List<Book> IsDelete(Book book)
        {
            Book existingBook = _libraryContext.Books.Find(book.BookID);
            _libraryContext.Remove(existingBook);
            _libraryContext.SaveChanges();
            return _libraryContext.Books.ToList();
        }
    }

}