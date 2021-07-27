using System;
using System.Collections.Generic;
using LibraryAPI.Models;


namespace LibraryAPI.Services
{

    public interface ILibraryService
    {
        interface IBookService
        {   
            IEnumerable<Book> GetList();
            Book CreateBook(BookDTO book);
            List<Book> EditBook(BookDTO book);
            List<Book> DeleteBook(BookDTO book);
            Book FindByID(int id);

        }

        interface ICategoryService{

            IEnumerable<Category> GetCategories();
            Category CreateCategory(Category category);
            List<Category> EditCategory(Category category);
            List<Category> DeleteCategory(Category category);
            Category FindByID(int id);
        }

    }

}