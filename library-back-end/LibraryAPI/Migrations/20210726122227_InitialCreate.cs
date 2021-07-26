using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequest",
                columns: table => new
                {
                    BookBorrowingRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRequest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowingRequest", x => x.BookBorrowingRequestID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequestDetail",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    BookBorrowingRequestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowingRequestDetail", x => new { x.BookBorrowingRequestID, x.UserID });
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequestDetail_BookBorrowingRequest_BookBorrowingRequestID",
                        column: x => x.BookBorrowingRequestID,
                        principalTable: "BookBorrowingRequest",
                        principalColumn: "BookBorrowingRequestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequestDetail_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequestDetail_UserID",
                table: "BookBorrowingRequestDetail",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "BookBorrowingRequestDetail");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "BookBorrowingRequest");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
