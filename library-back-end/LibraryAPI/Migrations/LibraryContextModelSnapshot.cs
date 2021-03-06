// <auto-generated />
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
                });

            modelBuilder.Entity("LibraryAPI.Models.BookBorrowingRequest", b =>
                {
                    b.Property<int>("BookBorrowingRequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AdminApproved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateRequest")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserRequest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookBorrowingRequestID");

                    b.ToTable("BookBorrowingRequest");
                });

            modelBuilder.Entity("LibraryAPI.Models.BookBorrowingRequestDetail", b =>
                {
                    b.Property<int>("BookBorrowingRequestID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("BookBorrowingRequestID", "UserID");

                    b.HasIndex("UserID");

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
                });

            modelBuilder.Entity("LibraryAPI.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LibraryAPI.Models.BookBorrowingRequestDetail", b =>
                {
                    b.HasOne("LibraryAPI.Models.BookBorrowingRequest", "BookBorrowingRequest")
                        .WithMany("BorrowingRequestDetails")
                        .HasForeignKey("BookBorrowingRequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryAPI.Models.User", "User")
                        .WithMany("BorrowingRequestDetails")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookBorrowingRequest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryAPI.Models.BookBorrowingRequest", b =>
                {
                    b.Navigation("BorrowingRequestDetails");
                });

            modelBuilder.Entity("LibraryAPI.Models.User", b =>
                {
                    b.Navigation("BorrowingRequestDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
