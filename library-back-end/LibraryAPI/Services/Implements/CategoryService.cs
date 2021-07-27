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
            using var transaction = _libraryContext.Database.BeginTransaction();
            try
            {
                var newCategory = new Category
                {
                    CategoryName = category.CategoryName,
                };
                _libraryContext.Categories.Add(newCategory);
                _libraryContext.SaveChanges();
                transaction.Commit();

                return newCategory;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<Category> EditCategory(Category category)
        {
            using var transaction = _libraryContext.Database.BeginTransaction();
            try
            {
                var existingCategory = _libraryContext.Categories.Find(category.CategoryID);

                if (existingCategory == null)
                {
                    return new List<Category>();
                }
                else
                {
                    existingCategory.CategoryName = category.CategoryName;

                    _libraryContext.Entry(existingCategory).State = EntityState.Modified;
                    _libraryContext.SaveChanges();
                    transaction.Commit();
                }
                return _libraryContext.Categories.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public Category FindByID(int id)
        {
            var existingCategory = _libraryContext.Categories.Find(id);

            return existingCategory;
        }

        public List<Category> DeleteCategory(Category category)
        {
            using var transaction = _libraryContext.Database.BeginTransaction();
            try
            {
                var existingCategory = _libraryContext.Categories.Find(category.CategoryID);
                if (existingCategory != null)
                {
                    _libraryContext.Remove(existingCategory);
                    _libraryContext.SaveChanges();
                    transaction.Commit();
                    return _libraryContext.Categories.ToList();
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