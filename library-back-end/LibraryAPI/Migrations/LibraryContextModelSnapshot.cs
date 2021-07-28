﻿// <auto-generated />
using System;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryAPI.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryAPI.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookID");

                    b.ToTable("Book");

                    b.HasData(
                        new
                        {
                            BookID = 1,
                            BookName = "Book 1"
                        });
                });

            modelBuilder.Entity("LibraryAPI.Models.BookBorrowingRequest", b =>
                {
                    b.Property<int>("BookBorrowingRequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminApproved")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateRequest")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("BookBorrowingRequestID");

                    b.HasIndex("UserID");

                    b.ToTable("BookBorrowingRequest");
                });

            modelBuilder.Entity("LibraryAPI.Models.BookBorrowingRequestDetail", b =>
                {
                    b.Property<int>("BookBorrowingRequestID")
                        .HasColumnType("int");

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int?>("number")
                        .HasColumnType("int");

                    b.HasKey("BookBorrowingRequestID", "BookID");

                    b.HasIndex("BookID");

                    b.ToTable("BookBorrowingRequestDetail");
                });

            modelBuilder.Entity("LibraryAPI.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Category 1"
                        });
                });

            modelBuilder.Entity("LibraryAPI.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("RoleAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            RoleAdmin = true,
                            UserEmail = "daotuan1@gmail.com",
                            UserName = "daotuan",
                            UserPassword = "123123"
                        },
                        new
                        {
                            UserID = 2,
                            RoleAdmin = true,
                            UserEmail = "daotuan2@gmail.com",
                            UserName = "dao",
                            UserPassword = "123123"
                        },
                        new
                        {
                            UserID = 3,
                            RoleAdmin = false,
                            UserEmail = "daotuan3@gmail.com",
                            UserName = "anh",
                            UserPassword = "123123"
                        },
                        new
                        {
                            UserID = 4,
                            RoleAdmin = false,
                            UserEmail = "daotuan4@gmail.com",
                            UserName = "tuan",
                            UserPassword = "123123"
                        });
                });

            modelBuilder.Entity("LibraryAPI.Models.BookBorrowingRequest", b =>
                {
                    b.HasOne("LibraryAPI.Models.User", "User")
                        .WithMany("BookBorrowingRequests")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryAPI.Models.BookBorrowingRequestDetail", b =>
                {
                    b.HasOne("LibraryAPI.Models.BookBorrowingRequest", "BookBorrowingRequest")
                        .WithMany("BorrowingRequestDetails")
                        .HasForeignKey("BookBorrowingRequestID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("LibraryAPI.Models.Book", "Book")
                        .WithMany("BorrowingRequestDetails")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("BookBorrowingRequest");
                });

            modelBuilder.Entity("LibraryAPI.Models.Book", b =>
                {
                    b.Navigation("BorrowingRequestDetails");
                });

            modelBuilder.Entity("LibraryAPI.Models.BookBorrowingRequest", b =>
                {
                    b.Navigation("BorrowingRequestDetails");
                });

            modelBuilder.Entity("LibraryAPI.Models.User", b =>
                {
                    b.Navigation("BookBorrowingRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
