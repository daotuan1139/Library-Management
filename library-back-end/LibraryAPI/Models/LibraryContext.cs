using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {
        }
        private const string connectionString = "data source=DESKTOP-DT75BB7;Database=Library;Integrated Security=SSPI;persist security info=True; ";
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(c => c.CategoryID).ValueGeneratedOnAdd();
            modelBuilder.Entity<BookBorrowingRequest>().Property(c => c.BookBorrowingRequestID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Book>().Property(c => c.BookID).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(c => c.UserID).ValueGeneratedOnAdd();
            modelBuilder.Entity<BookBorrowingRequestDetail>().HasKey(d => new { d.BookBorrowingRequestID, d.BookID });

            modelBuilder.Entity<BookBorrowingRequestDetail>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BorrowingRequestDetails)
                .HasForeignKey(bc => bc.BookID)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired();

            modelBuilder.Entity<BookBorrowingRequestDetail>()
                .HasOne(bc => bc.BookBorrowingRequest)
                .WithMany(b => b.BorrowingRequestDetails)
                .HasForeignKey(bc => bc.BookBorrowingRequestID)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired();

            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookID = 1,
                BookName = "Book 1",
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryID = 1,
                CategoryName = "Category 1",
            });
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, UserName = "daotuan", UserEmail = "daotuan1@gmail.com", UserPassword = "123123", RoleAdmin = true},
                new User { UserID = 2, UserName = "dao", UserEmail = "daotuan2@gmail.com", UserPassword = "123123", RoleAdmin = true},
                new User { UserID = 3, UserName = "anh", UserEmail = "daotuan3@gmail.com", UserPassword = "123123", RoleAdmin = false},
                new User { UserID = 4, UserName = "tuan", UserEmail = "daotuan4@gmail.com", UserPassword = "123123", RoleAdmin = false}
                );
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookBorrowingRequest> BookBorrowingRequests { get; set; }
        public DbSet<BookBorrowingRequestDetail> BookBorrowingRequestDetails { get; set; }

    }
}