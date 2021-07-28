using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryAPI.Migrations
{
    public partial class initialCreate : Migration
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
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequest",
                columns: table => new
                {
                    BookBorrowingRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DateRequest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminApproved = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowingRequest", x => x.BookBorrowingRequestID);
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequest_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequestDetail",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false),
                    BookBorrowingRequestID = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowingRequestDetail", x => new { x.BookBorrowingRequestID, x.BookID });
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequestDetail_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequestDetail_BookBorrowingRequest_BookBorrowingRequestID",
                        column: x => x.BookBorrowingRequestID,
                        principalTable: "BookBorrowingRequest",
                        principalColumn: "BookBorrowingRequestID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "BookID", "BookName" },
                values: new object[] { 1, "Book 1" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Category 1" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "RoleAdmin", "UserEmail", "UserName", "UserPassword" },
                values: new object[,]
                {
                    { 1, true, "daotuan1@gmail.com", "daotuan", "123123" },
                    { 2, true, "daotuan2@gmail.com", "dao", "123123" },
                    { 3, false, "daotuan3@gmail.com", "anh", "123123" },
                    { 4, false, "daotuan4@gmail.com", "tuan", "123123" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequest_UserID",
                table: "BookBorrowingRequest",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequestDetail_BookID",
                table: "BookBorrowingRequestDetail",
                column: "BookID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBorrowingRequestDetail");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "BookBorrowingRequest");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
