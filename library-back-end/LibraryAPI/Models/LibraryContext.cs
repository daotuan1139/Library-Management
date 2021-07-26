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
            modelBuilder.Entity<BookBorrowingRequestDetail>().HasKey(d => new { d.BookBorrowingRequestID, d.UserID });

            modelBuilder.Entity<BookBorrowingRequestDetail>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.BorrowingRequestDetails)
                .HasForeignKey(bc => bc.UserID);

            modelBuilder.Entity<BookBorrowingRequestDetail>()
                .HasOne(bc => bc.BookBorrowingRequest)
                .WithMany(b => b.BorrowingRequestDetails)
                .HasForeignKey(bc => bc.BookBorrowingRequestID);

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookBorrowingRequest> BookBorrowingRequests { get; set; }
        public DbSet<BookBorrowingRequestDetail> BookBorrowingRequestDetails { get; set; }

    }
}