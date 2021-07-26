using System;
using System.Collections.Generic;
using System.Linq;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using static LibraryAPI.Services.ILibraryService;

namespace LibraryAPI.Services
{

    public class CategoryService : ICategoryService
    {
        private LibraryContext _libraryContext;
        public CategoryService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        //CRUD

        public IEnumerable<Category> GetCategories()
        {
            return _libraryContext.Categories.ToList();
        }
        public Category CreateCategory(Category category)
        {
            var newCategory = new Category
                {
                   CategoryName = category.CategoryName,
                };
            _libraryContext.Categories.Add(newCategory);
            _libraryContext.SaveChanges();

            return newCategory;
        }

        public List<Category> EditCategory(Category category)
        {
            Category existingCategory = _libraryContext.Categories.Find(category.CategoryID);

            if (existingCategory == null)
            {
                return new List<Category>();
            }
            else
            {
                existingCategory.CategoryName = category.CategoryName;

                _libraryContext.Entry(existingCategory).State = EntityState.Modified;
                _libraryContext.SaveChanges();
            }
            return _libraryContext.Categories.ToList();
        }

        public Category FindByID(int id)
        {
            Category existingCategory = _libraryContext.Categories.Find(id);

            return existingCategory;
        }

        public List<Category> IsDelete(Category category)
        {
             Category existingCategory = _libraryContext.Categories.Find(category.CategoryID);
            _libraryContext.Remove(existingCategory);
            _libraryContext.SaveChanges();
            return _libraryContext.Categories.ToList();
        }
    }

}