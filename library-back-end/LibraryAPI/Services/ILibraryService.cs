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
            Book CreateBook(Book book);
            List<Book> EditBook(Book book);
            List<Book> IsDelete(Book book);
            Book FindByID(int id);

        }

        interface ICategoryService{

            IEnumerable<Category> GetCategories();
            Category CreateCategory(Category category);
            List<Category> EditCategory(Category category);
            List<Category> IsDelete(Category category);
            Category FindByID(int id);
        }

    }

}