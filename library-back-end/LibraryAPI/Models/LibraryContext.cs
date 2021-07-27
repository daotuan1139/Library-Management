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
            modelBuilder.Entity<NormalUser>().Property(c => c.NormalUserID).ValueGeneratedOnAdd();
            modelBuilder.Entity<SuperUser>().Property(c => c.SuperUserID).ValueGeneratedOnAdd();
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
            modelBuilder.Entity<NormalUser>().HasData(new NormalUser
            {
                NormalUserID = 1,
                NormalUserEmail = "1",
                NormalUserPassword = "1",
                NormalUserName = "user 1", 
            });
            modelBuilder.Entity<SuperUser>().HasData(new SuperUser
            {
                SuperUserID = 1,
                SuperUserEmail = "1",
                SuperUserPassword = "1",
                SuperUserName = "admin 1", 
            });

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<NormalUser> NormalUsers { get; set; }
        public DbSet<SuperUser> SuperUsers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookBorrowingRequest> BookBorrowingRequests { get; set; }
        public DbSet<BookBorrowingRequestDetail> BookBorrowingRequestDetails { get; set; }

    }
}